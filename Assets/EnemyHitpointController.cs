using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitpointController : MonoBehaviour
{
	public int maxHealth = 1;
	public int currentHitpoints = 0;

	// Start is called before the first frame update
	void Start()
	{
		currentHitpoints = maxHealth;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void HealDamage(int amount)
	{
		currentHitpoints = Mathf.Min(currentHitpoints + amount, maxHealth);
	}

	public void TakeDamage(int amount)
	{
		currentHitpoints = Mathf.Max(currentHitpoints - amount, 0);
	}
}
