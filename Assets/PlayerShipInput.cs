using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipInput : MonoBehaviour
{

	bool bAttack1 = false;
	bool bAttack2 = false;


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
	}


	public void TriggerWeapons()
	{
		List<PlayerWeapon> playerWeapons = GetComponentsInChildren<PlayerWeapon>().ToList();
		playerWeapons.ForEach(weapon => weapon.TriggerWeapon());
	}
}
