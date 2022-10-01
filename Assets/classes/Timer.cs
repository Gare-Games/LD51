using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Timer
{
	public float frequency = 0.0f;
	private float timer = 0.0f;
	private bool bStarted = false;

	public void Interval()
	{
		if (bStarted && !IsFinished())
			timer += Time.deltaTime;
	}

	public void Start()
	{
		bStarted = true;
	}

	public bool HasStarted()
	{
		return bStarted;
	}

	public void Stop()
	{
		bStarted = false;
	}

	public void Reset()
	{
		timer = 0.0f;
		bStarted = false;
	}

	public void ResetAndStart()
	{
		Reset();
		Start();
	}

	public bool IsFinished()
	{
		return bStarted && timer >= frequency;
	}
}