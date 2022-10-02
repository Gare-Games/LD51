using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class EnemyHitByBullet : MonoBehaviour
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
		if (collision.gameObject.layer != LayerMask.NameToLayer(LayerConstants.PlayerProjectile)) return;

		EnemyHitpointController enemyHitpointController = GetComponent<EnemyHitpointController>();
		if (enemyHitpointController != null)
		{
			//TODO: Make the damage object
			enemyHitpointController.TakeDamage(1);
			OnHitFlash onHitFlash = GetComponent<OnHitFlash>();
			if (onHitFlash != null) onHitFlash.TriggerFlash();

			//Destroy the bullet.
			Destroy(collision.gameObject);

			if ( enemyHitpointController.currentHitpoints <= 0)
			{
				//Destroy the enemy
				Destroy(gameObject);
			}
		}
	}
}

