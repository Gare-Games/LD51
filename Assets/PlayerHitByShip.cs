using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class PlayerHitByShip : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer(LayerConstants.Enemy)) return;

		PlayerHitpointsController playerHitpointsController = GetComponent<PlayerHitpointsController>();
		playerHitpointsController.TakeDamage(1);

		OnHitFlash onHitFlash = GetComponent<OnHitFlash>();
		if (onHitFlash != null)
			onHitFlash.TriggerFlash();


		// Some lose condition.
	}
}
