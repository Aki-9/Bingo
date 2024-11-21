using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObstacleController : MonoBehaviour
{

	[SerializeField]
	protected float waitTime = 0;

	protected bool stop = false;

	protected virtual void Start()
	{
		
	}

	protected virtual void Update()
	{
		
	}

	protected IEnumerator WaitTimer()
	{
		stop = true;

		yield return new WaitForSeconds(waitTime);

		stop = false;
	}

}
