using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeSelectorController : MonoBehaviour
{
	// Start is called before the first frame update
	public OptionDetails option1;
	public OptionDetails option2;
	public OptionDetails option3;

	public PlayerUpgradeController playerUpgradeController;
	public EnemyUpgradeController enemyUpgradeController;
	public SpawnableEnemiesList spawnableEnemiesList;

	public GameObject pickAnUpgrade;
	public bool bShowUpgrade = false;



	void Start()
	{
		HideUpgradeList();
	}

	// Update is called once per frame
	void Update()
	{
		if (bShowUpgrade)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			if (enemies.Length == 0)
				pickAnUpgrade.SetActive(true);
		}
	}

	public void RefreshUpgradeList()
	{
		List<UpgradeConfig> upgradeConfigs = playerUpgradeController.upgradeConfigs;
		List<UpgradeConfig> enemyUpgradeConfigs = enemyUpgradeController.enemyUpgradeConfigs;
		List<EnemySpawnConfig> enemyToSpawnConfigs = spawnableEnemiesList.enemySpawnConfigs;


		//Player Upgrades
		option1.SetPlayerUpgradeConfig(upgradeConfigs[Random.Range(0, upgradeConfigs.Count)]);
		option2.SetPlayerUpgradeConfig(upgradeConfigs[Random.Range(0, upgradeConfigs.Count)]);
		option3.SetPlayerUpgradeConfig(upgradeConfigs[Random.Range(0, upgradeConfigs.Count)]);

		//Enemy Upgrades
		option1.SetEnemyUpgradeConfig(enemyUpgradeConfigs[Random.Range(0, enemyUpgradeConfigs.Count)]);
		option2.SetEnemyUpgradeConfig(enemyUpgradeConfigs[Random.Range(0, enemyUpgradeConfigs.Count)]);
		option3.SetEnemyUpgradeConfig(enemyUpgradeConfigs[Random.Range(0, enemyUpgradeConfigs.Count)]);

		//Enemy To Spawn
		option1.SetEnemyToSpawnConfig(enemyToSpawnConfigs[Random.Range(0, enemyToSpawnConfigs.Count)]);
		option2.SetEnemyToSpawnConfig(enemyToSpawnConfigs[Random.Range(0, enemyToSpawnConfigs.Count)]);
		option3.SetEnemyToSpawnConfig(enemyToSpawnConfigs[Random.Range(0, enemyToSpawnConfigs.Count)]);
	}

	public void ShowUpgradeList()
	{
		option1.gameObject.SetActive(true);
		option2.gameObject.SetActive(true);
		option3.gameObject.SetActive(true);
		bShowUpgrade = true;
	}

	public void HideUpgradeList()
	{
		option1.gameObject.SetActive(false);
		option2.gameObject.SetActive(false);
		option3.gameObject.SetActive(false);
		pickAnUpgrade.SetActive(false);
		bShowUpgrade = false;
	}
}