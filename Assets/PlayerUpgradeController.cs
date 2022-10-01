using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUpgradeController : MonoBehaviour
{
	public List<UpgradeConfig> upgradeConfigs;



	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	public float GetVerticalSpeed()
	{
		return 0;
	}

	public float GetForwardSpeed()
	{
		return 0;
	}

	public float GetBackwardSpeed()
	{
		return 0;
	}

	public void ReduceHandlingTime()
	{
		// Do something to the timers on the player movement controller.
	}

	public void IncreasebulletCount()
	{
		Debug.Log("Bullet Count Increased");
	}
}

[System.Serializable]
public class UpgradeConfig
{
	public Sprite upgradeIcon;
	public UnityEvent unityEvent;
}
