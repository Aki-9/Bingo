using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-10)]
public class MoveSceneManager : SingletonMonoBehaviour<MoveSceneManager>
{

	[SerializeField, Tooltip("フェードイン、フェードアウトの間の待ち時間")]
	float fadeWaitTime = 1;
	[SerializeField, Tooltip("トランジションに使用するカンバスのプレハブ")]
	GameObject fadeCanvasPrefab = null;

	int currentSceneNum = 0;    //現在のステージ番号（0始まり）
	GameObject fadeCanvasObj;
	FadeCanvas fadeCanvas;
	GameManager gameManager;

	public int CurrentSceneNum
	{
		set
		{
			currentSceneNum = Mathf.Clamp(value, 0, SceneManager.sceneCountInBuildSettings - 1);
		}
		get
		{
			return currentSceneNum;
		}
	}

	//BuildSettingに登録されているシーンの数を取得
	//ただし、エディタ上で登録されてないシーンを読んでいる状態だとそのシーンも数に含まれるので注意
	public int NumOfScene
	{
		get
		{
			return SceneManager.sceneCountInBuildSettings;
		}
	}

	public string SceneName
	{
		get
		{
			return SceneManager.GetActiveScene().name;
		}
	}

	void Start()
	{
		gameManager = GetComponent<GameManager>();

		//デリゲートの登録
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	//シーンのロード時に実行（最初は実行されない）
	protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		gameManager.ExecWhenLoadScene();
	}

	//シーンの読み込みと待機を行うコルーチン
	IEnumerator WaitForLoadScene(int sceneNum)
	{
		CurrentSceneNum = sceneNum;

		//フェードオブジェクトを生成
		fadeCanvasObj = Instantiate(fadeCanvasPrefab);

		//コンポーネントを取得
		fadeCanvas = fadeCanvasObj.GetComponent<FadeCanvas>();

		//フェードインさせる
		fadeCanvas.fadeIn = true;

		yield return new WaitForSeconds(fadeWaitTime);

		//シーンを非同期で読込し、読み込まれるまで待機する
		yield return SceneManager.LoadSceneAsync(sceneNum);

		//フェードアウトさせる
		fadeCanvas.fadeOut = true;

		yield return new WaitForSeconds(fadeWaitTime);

		Destroy(fadeCanvasObj);
	}

	//指定したインデックスのステージに移動する処理
	public void MoveToScene(int sceneNum)
	{
		//コルーチンを実行
		StartCoroutine(WaitForLoadScene(sceneNum));
	}

}

