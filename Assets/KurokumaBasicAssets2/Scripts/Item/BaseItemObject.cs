using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItemObject : MonoBehaviour
{

	GameManager gameManager;

	protected virtual void Start()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

		InitItem();
	}
	
	protected virtual void InitItem()
	{

	}

	public virtual void GetItem()
	{

	}

	public virtual void DestroyItem()
	{
		Destroy(gameObject);
	}

}
