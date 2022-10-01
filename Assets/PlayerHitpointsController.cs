using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpointsController : MonoBehaviour
{

	public int hitpointMax = 5;
	public int hitpoints = 0;

	// Start is called before the first frame update
	void Start()
	{
		hitpoints = hitpointMax;
	}

	public void HealDamage(int amount)
	{ 
		hitpoints = Mathf.Min(hitpoints + amount, hitpointMax);
	}

	public void TakeDamage(int amount)
	{
		hitpoints = Mathf.Max(hitpoints - amount, 0);
	}
}
