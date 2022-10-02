using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class PlayerHitByBullet : MonoBehaviour
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
		if (collision.gameObject.layer != LayerMask.NameToLayer(LayerConstants.EnemyProjectile)) return;

		PlayerHitpointsController playerHitpointsController = GetComponent<PlayerHitpointsController>();
		playerHitpointsController.TakeDamage(1);

		if (playerHitpointsController.hitpoints <= 0)
		{
			Globals.GameController.ShowGameOver();
			Destroy(gameObject);
		}
			

		OnHitFlash onHitFlash = GetComponent<OnHitFlash>();
		if (onHitFlash != null)
			onHitFlash.TriggerFlash();
	}
}
