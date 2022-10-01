using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.classes;


public class PlayerShipInput : MonoBehaviour
{

	bool bAttack1 = false;
	bool bAttack2 = false;


	public GameObject defaultBoat;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		GatherInput();

		if (bAttack1)
			TriggerWeapons();
	}

	public void GatherInput()
	{
		bAttack1 = false;
		if (Keyboard.current[Key.Z].isPressed)
		{
			bAttack1 = true;
		}
		if (Keyboard.current[Key.X].isPressed)
		{
			Debug.Log("Attack2");
		}

		if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
		{
			//Upgrade1
			Globals.GameController.AddToTopSpawner(defaultBoat);
		}
		if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
		{
			//Upgrade2
			Globals.GameController.AddToMidSpawner(defaultBoat);
		}
		if (Keyboard.current[Key.Digit3].wasPressedThisFrame)
		{
			//Upgrade3
			Globals.GameController.AddToBottomSpawner(defaultBoat);
		}
		if (Keyboard.current[Key.Digit4].wasPressedThisFrame)
		{
			// Reroll
		}
	}


	public void TriggerWeapons()
	{
		List<PlayerWeapon> playerWeapons = GetComponentsInChildren<PlayerWeapon>().ToList();
		playerWeapons.ForEach(weapon => weapon.TriggerWeapon());
	}
}
