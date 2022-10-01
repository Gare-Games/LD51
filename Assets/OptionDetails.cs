using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionDetails : MonoBehaviour
{
	public SpriteRenderer playerUpgrade;
	public SpriteRenderer enemyUpgrade;
	public SpriteRenderer enemyToSpawnSprite;
	public SpawnerController spawnerController;
	private UpgradeConfig playerUpgradeConfig;
	private UpgradeConfig enemyUpgradeConfig;
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

	public void SetEnemyUpgradeConfig(UpgradeConfig upgradeConfig)
	{
		enemyUpgradeConfig = upgradeConfig;
		enemyUpgrade.sprite = enemyUpgradeConfig.upgradeIcon;
	}

	public void SetEnemyToSpawnConfig(EnemySpawnConfig enemySpawnConfig)
	{
		enemyToSpawnConfig = enemySpawnConfig;
		enemyToSpawnSprite.sprite = enemyToSpawnConfig.enemyIcon;
	}

	public void Select()
	{
		playerUpgradeConfig.unityEvent.Invoke();
		enemyUpgradeConfig.unityEvent.Invoke();
		spawnerController.Add(enemyToSpawnConfig.enemyToSpawn);
	}
}
