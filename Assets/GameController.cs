using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;
using TMPro;

public class GameController : MonoBehaviour
{
	public SpawnerController TopSpawner;
	public SpawnerController MidSpawner;
	public SpawnerController BottomSpawner;

	public Timer gameTimer;

	public TMP_Text tenSecondTimer;

	// Start is called before the first frame update
	void Start()
	{
		Globals.GameController = this;
		gameTimer.Start();
	}

	// Update is called once per frame
	void Update()
	{
		gameTimer.Interval();
		tenSecondTimer.SetText(gameTimer.GetTimeLeft());
		if (gameTimer.IsFinished())
		{
			gameTimer.ResetAndStart();
			TopSpawner.ResetAndStartSpawner();
			MidSpawner.ResetAndStartSpawner();
			BottomSpawner.ResetAndStartSpawner();
		}
	}

	public void AddToTopSpawner(GameObject gameObject)
	{
		TopSpawner.Add(gameObject);
	}

	public void AddToMidSpawner(GameObject gameObject)
	{
		MidSpawner.Add(gameObject);
	}

	public void AddToBottomSpawner(GameObject gameObject)
	{
		BottomSpawner.Add(gameObject);
	}
}
