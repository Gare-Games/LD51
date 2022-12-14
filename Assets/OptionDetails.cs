using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class OptionDetails : MonoBehaviour
{
	public SpriteRenderer playerUpgrade;
	public SpriteRenderer enemyToSpawnSprite;
	public SpawnerController spawnerController;
	private UpgradeConfig playerUpgradeConfig;
	private EnemySpawnConfig enemyToSpawnConfig;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SetPlayerUpgradeConfig(UpgradeConfig upgradeConfig)
	{
		playerUpgradeConfig = upgradeConfig;
		playerUpgrade.sprite = playerUpgradeConfig.upgradeIcon;
	}

	public void SetEnemyToSpawnConfig(EnemySpawnConfig enemySpawnConfig)
	{
		enemyToSpawnConfig = enemySpawnConfig;
		enemyToSpawnSprite.sprite = enemyToSpawnConfig.enemyIcon;
	}

	public void Select()
	{
		Globals.GameController.PlaySelectSound();
		Globals.GameController.IncrementLevelCount();
		playerUpgradeConfig.unityEvent.Invoke();

		for(int i = 0; i < enemyToSpawnConfig.amount; i++)
			spawnerController.Add(enemyToSpawnConfig.enemyToSpawn);
		
	}
}
