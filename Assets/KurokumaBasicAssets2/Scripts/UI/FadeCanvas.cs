using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{

	[System.NonSerialized]
	public bool fadeIn = false;
	[System.NonSerialized]
	public bool fadeOut = false;
	[SerializeField, Tooltip("フェードの速さ")]
	float fadeSpeed = 1f;

	float red, green, blue, alpha;
	Image panelImage;

	//最初の処理
	void Start()
	{
		DontDestroyOnLoad(gameObject);

		panelImage = GetComponentInChildren<Image>();

		//元の色を取得
		red = panelImage.color.r;
		green = panelImage.color.g;
		blue = panelImage.color.b;
		alpha = panelImage.color.a;
	}

	//毎フレームの処理
	void Update()
	{
		if (fadeIn)
		{
			FadeIn();
		}
		else if (fadeOut)
		{
			FadeOut();
		}
	}

	//フェードイン
	void FadeIn()
	{
		alpha += fadeSpeed * Time.deltaTime;

		SetAlpha();

		if (alpha >= 1)
		{
			fadeIn = false;
		}
	}

	//フェードアウト
	void FadeOut()
	{
		alpha -= fadeSpeed * Time.deltaTime;

		SetAlpha();

		if (alpha <= 0)
		{
			fadeOut = false;

			Destroy(gameObject);
		}
	}

	//透明度を変更
	void SetAlpha()
	{
		panelImage.color = new Color(red, green, blue, alpha);
	}
}
