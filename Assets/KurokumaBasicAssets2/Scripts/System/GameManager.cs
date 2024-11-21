using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveSceneManager))]
[RequireComponent(typeof(SaveManager))]
[RequireComponent(typeof(SoundManager))]
[DefaultExecutionOrder(-5)]
public class GameManager : SingletonMonoBehaviour<GameManager>
{

	[Header("シーンロード時に自動生成するプレハブを登録")]
	[SerializeField]
	GameObject[] prefabs = null;

	bool isClear = false;
	bool isGameOver = false;
	MoveSceneManager moveSceneManager;
	SaveManager saveManager;
	SoundManager soundManager;

	protected override void Awake()
	{
		base.Awake();

		if (Debug.isDebugBuild)
		{
			
		}

		moveSceneManager = GetComponent<MoveSceneManager>();
		saveManager = GetComponent<SaveManager>();
		soundManager = GetComponent<SoundManager>();
	}

	void Start()
	{
		//デバッグ用。テストプレイするときに必要な処理を行う
		if (Debug.isDebugBuild)
		{
			ExecWhenLoadScene();
		}
	}

	void Update()
	{
        
	}

	//シーンが読み込まれたときに実行されるメソッド（最初は実行されない）
	public void ExecWhenLoadScene()
	{
		if (moveSceneManager.SceneName == "Title")
		{
			return;
		}

		InstantiateWhenLoadScene();
		InitGame();
	}

	public void InstantiateWhenLoadScene()
	{
		if (moveSceneManager.SceneName == "Title")
		{
			return;
		}

		foreach (GameObject prefab in prefabs)
		{
			Instantiate(prefab, transform.position, Quaternion.identity);
		}
	}

	void InitGame()
	{
		isClear = false;
		isGameOver = false;
	}

	public void StageClear()
	{
		if(isClear || isGameOver)
		{
			return;
		}

		isClear = true;

		//★ここにステージクリア時の処理

	}

	public void GameOver()
	{
		if (isClear || isGameOver)
		{
			return;
		}

		isGameOver = true;

		//★ここにゲームオーバー時の処理

	}

	public void Retry()
	{

	}

}


