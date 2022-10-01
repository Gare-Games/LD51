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
	public Globals.Direction direction;
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

		if(shotFrequency.IsFinished())
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
				bulletConfiguration.Initialize(Globals.rotate(Vector2.right, varianceAngle));
			}

			shotFrequency.ResetAndStart();
		}

	}
}
