using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEnemiesList : MonoBehaviour
{
	public List<EnemySpawnConfig> enemySpawnConfigs;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}

[System.Serializable]
public class EnemySpawnConfig
{
	public Sprite enemyIcon;
	public GameObject enemyToSpawn;
	public int amount;
}
