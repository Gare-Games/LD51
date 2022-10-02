using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class PlayerWeapon : MonoBehaviour
{
	public Timer shotFrequency;
	public Timer reloadTimer;
	public int maxAmmo;
	public bool hasAmmo;
	public Globals.Direction direction = Globals.Direction.right;
	public GameObject projectileToSpawn;
	public float bulletVariance = 15.0f;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		shotFrequency.Interval();

		if (shotFrequency.IsFinished())
			shotFrequency.Reset();
	}

	public void TriggerWeapon()
	{
		if (!shotFrequency.HasStarted())
		{
			// Shoot
			GameObject bulletObj = Instantiate(projectileToSpawn, gameObject.transform.position, Quaternion.identity);
			BulletConfiguration bulletConfiguration = bulletObj.GetComponent<BulletConfiguration>();
			if (bulletConfiguration != null)
			{
				float varianceAngle = Random.Range(-bulletVariance, bulletVariance);
				Vector2 startDirection = Vector2.right;
				switch (direction)
				{
					case Globals.Direction.right:
						startDirection = Vector2.right;
						break;
					case Globals.Direction.upright:
						startDirection = Globals.rotate(Vector2.right, 15.0f);
						break;
					case Globals.Direction.downright:
						startDirection = Globals.rotate(Vector2.right, -15.0f);
						break;
					default:
						startDirection = Vector2.right;
						break;
				}

				Vector2 shotDirection = Globals.rotate(startDirection, varianceAngle);


				bulletConfiguration.Initialize(shotDirection);
			}

			shotFrequency.ResetAndStart();
		}

	}
}
