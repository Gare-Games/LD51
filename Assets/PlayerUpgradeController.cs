using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class PlayerUpgradeController : MonoBehaviour
{
	public List<UpgradeConfig> upgradeConfigs;

	public int maxBulletUpgrades = 10;
	public int currentBulletUpgrades = 0;

	public void AddBulletUpgrade()
	{
		currentBulletUpgrades++;

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		List<PlayerWeapon> playerWeapons = player.GetComponentsInChildren<PlayerWeapon>().ToList();
		PlayerWeapon playerWeaponToEnable = playerWeapons.FirstOrDefault(weapon => weapon.enabled == false);
		if (playerWeaponToEnable != null)
			playerWeaponToEnable.enabled = true;

		if (currentBulletUpgrades >= maxBulletUpgrades)
		{
			RemoveUpgradeConfig("bulletSplit");
		}
	}


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

	public void RemoveUpgradeConfig(string spriteName)
	{
		UpgradeConfig configToRemove = new UpgradeConfig();

		foreach (var config in upgradeConfigs)
		{
			if (config.upgradeIcon.name == spriteName)
				configToRemove = config;
		}

		if (configToRemove.upgradeIcon != null)
		{
			upgradeConfigs.Remove(configToRemove);
		}
	}
}

[System.Serializable]
public class UpgradeConfig
{
	public Sprite upgradeIcon;
	public UnityEvent unityEvent;
}
