using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : BaseButtonController
{

	SaveManager saveManager;

	void Start()
	{
		saveManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SaveManager>();
	}

	public override void OnClick()
	{
		saveManager.Save();
	}

}
