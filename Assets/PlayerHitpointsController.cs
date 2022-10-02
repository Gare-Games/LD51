using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class PlayerHitpointsController : MonoBehaviour
{

	public int hitpointMax = 5;
	public int hitpoints = 0;

	bool initialized = false;

	// Start is called before the first frame update
	void Start()
	{
		hitpoints = hitpointMax;
		if (Globals.GameController != null)
		{
			Globals.GameController.UpdateHealth(hitpoints);
			initialized = true;
		}
		
	}

	private void Update()
	{
		if (!initialized && Globals.GameController != null)
		{
			Globals.GameController.UpdateHealth(hitpoints);
			initialized = true;
		}
	}

	public void HealDamage(int amount)
	{ 
		hitpoints = Mathf.Min(hitpoints + amount, hitpointMax);
		Globals.GameController.UpdateHealth(hitpoints);
	}

	public void TakeDamage(int amount)
	{
		hitpoints = Mathf.Max(hitpoints - amount, 0);
		Globals.GameController.UpdateHealth(hitpoints);
	}
}
