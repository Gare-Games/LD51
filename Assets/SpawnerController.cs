using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	public Timer trackTimer;

	public List<SpawnerConfig> row1 = new List<SpawnerConfig>();
	public List<SpawnerConfig> row2 = new List<SpawnerConfig>();
	public List<SpawnerConfig> row3 = new List<SpawnerConfig>();
	public List<SpawnerConfig> row4 = new List<SpawnerConfig>();
	public List<SpawnerConfig> row5 = new List<SpawnerConfig>();


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		trackTimer.Interval();

		if (trackTimer.IsFinished()) return;

		foreach(SpawnerConfig config in row1)
			Spawn(config, trackTimer.GetTimeElapsed(), -0.6f);

		foreach (SpawnerConfig config in row2)
			Spawn(config, trackTimer.GetTimeElapsed(), -0.3f);

		foreach (SpawnerConfig config in row3)
			Spawn(config, trackTimer.GetTimeElapsed(), 0.0f);

		foreach (SpawnerConfig config in row4)
			Spawn(config, trackTimer.GetTimeElapsed(), 0.3f);

		foreach (SpawnerConfig config in row5)
			Spawn(config, trackTimer.GetTimeElapsed(), 0.6f);
	}


	public void ResetAndStartSpawner()
	{
		trackTimer.ResetAndStart();
		row1.ForEach(spawnConfig => spawnConfig.hasSpawned = false);
		row2.ForEach(spawnConfig => spawnConfig.hasSpawned = false);
		row3.ForEach(spawnConfig => spawnConfig.hasSpawned = false);
		row4.ForEach(spawnConfig => spawnConfig.hasSpawned = false);
		row5.ForEach(spawnConfig => spawnConfig.hasSpawned = false);
	}

	public void Add(GameObject gameObject)
	{
		int row = Random.Range(0, 5) + 1;

		float whenToSpawnSetting = Random.Range(0.1f, 9.9f);
		SpawnerConfig spawnerConfig = new SpawnerConfig() { spawnThisObject = gameObject, whenToSpawn = whenToSpawnSetting };

		switch (row)
		{ 
			case 1:
				row1.Add(spawnerConfig);
				break;
			case 2:
				row2.Add(spawnerConfig);
				break;
			case 3:
				row3.Add(spawnerConfig);
				break;
			case 4:
				row4.Add(spawnerConfig);
				break;
			case 5:
				row5.Add(spawnerConfig);
				break;
		}
	}

	public void Spawn(SpawnerConfig config, float currentTimeElapsed, float yValue)
	{
		if (config.hasSpawned) return;

		//TODO use the yValue as the input.
		if (trackTimer.GetTimeElapsed() > config.whenToSpawn)
		{
			config.hasSpawned = true;
			Instantiate(config.spawnThisObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + yValue, 0), Quaternion.identity);
		}
			
	}
}


[System.Serializable]
public class SpawnerConfig
{
	public GameObject spawnThisObject;
	[Range(0.0f, 10.0f)]
	public float whenToSpawn;
	public bool hasSpawned = false;


}
