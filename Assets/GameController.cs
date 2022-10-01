using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;
using TMPro;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
	public SpawnerController TopSpawner;
	public SpawnerController MidSpawner;
	public SpawnerController BottomSpawner;
	public UpgradeSelectorController upgradeSelectorController;

	public Timer gameTimer;

	public TMP_Text tenSecondTimer;
	public TMP_Text hitpointsText;

	// Start is called before the first frame update
	void Start()
	{
		Globals.GameController = this;
		gameTimer.Start();
		TopSpawner.ResetAndStartSpawner();
		MidSpawner.ResetAndStartSpawner();
		BottomSpawner.ResetAndStartSpawner();

	}

	// Update is called once per frame
	void Update()
	{
		gameTimer.Interval();
		tenSecondTimer.SetText(gameTimer.GetTimeLeft());
		if (gameTimer.IsFinished())
		{
			upgradeSelectorController.ShowUpgradeList();
			upgradeSelectorController.RefreshUpgradeList();
			gameTimer.Reset();
		}

		if (gameTimer.HasStarted())
		{
			upgradeSelectorController.HideUpgradeList();
		}

		if (!gameTimer.HasStarted())
		{
			if (Keyboard.current != null)
			{
				var keyboard = Keyboard.current;

				if (keyboard[Key.Digit1].wasPressedThisFrame)
				{
					upgradeSelectorController.option1.Select();
					StartWave();
				}
				else if (keyboard[Key.Digit2].wasPressedThisFrame)
				{
					upgradeSelectorController.option2.Select();
					StartWave();
				}
				else if (keyboard[Key.Digit3].wasPressedThisFrame)
				{
					upgradeSelectorController.option3.Select();
					StartWave();
				}
				else if (keyboard[Key.Digit4].wasPressedThisFrame)
				{
					//upgradeSelectorController.option1.Select();
					StartWave();
				}
			}
		}
	}

	public void StartWave()
	{
		gameTimer.ResetAndStart();
		TopSpawner.ResetAndStartSpawner();
		MidSpawner.ResetAndStartSpawner();
		BottomSpawner.ResetAndStartSpawner();
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

	public void UpdateHealth(int health)
	{
		if (hitpointsText != null)
			hitpointsText.SetText($"HP: {health}");
	}
}
