using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SystemButton : BaseButtonController
{

	public enum ButtonMode { NextStage, Retry, Title, };

	[SerializeField]
	ButtonMode mode = ButtonMode.NextStage;

	GameObject gameManagerObj;
	GameManager gameManager;
	MoveSceneManager moveSceneManager;

	void Start()
	{
		gameManagerObj = GameObject.FindGameObjectWithTag("GameController");
		gameManager = gameManagerObj.GetComponent<GameManager>();
		moveSceneManager = gameManagerObj.GetComponent<MoveSceneManager>();

		//次に進むボタンは、次のステージがなければ押せないようにする
		if(mode == ButtonMode.NextStage && moveSceneManager.CurrentSceneNum >= moveSceneManager.NumOfScene - 1)
		{
			GetComponent<Button>().interactable = false;
		}
	}

	public override void OnClick()
	{
		switch (mode)
		{
			case ButtonMode.NextStage:
				if(moveSceneManager.CurrentSceneNum < moveSceneManager.NumOfScene - 1)
				{
					moveSceneManager.MoveToScene(moveSceneManager.CurrentSceneNum + 1);
				}
				break;
			case ButtonMode.Retry:
				gameManager.Retry();
				break;
			case ButtonMode.Title:
				moveSceneManager.MoveToScene(0);	//ビルドインデックス0番（＝タイトルシーン）に移動
				break;
		}
	}

}
