using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class ShootOnInterval : MonoBehaviour
{
	public Timer shotTimer;
	public GameObject projectileToSpawn;
	public float shotVariance = 4.5f;


	// Start is called before the first frame update
	void Start()
	{
		shotTimer.Start();
	}

	// Update is called once per frame
	void Update()
	{
		shotTimer.Interval();
		if (shotTimer.IsFinished())
		{
			GameObject bulletObj = Instantiate(projectileToSpawn, gameObject.transform.position, Quaternion.identity);
			BulletConfiguration bulletConfiguration = bulletObj.GetComponent<BulletConfiguration>();
			if (bulletConfiguration != null)
			{
				float varianceAngle = Random.Range(-shotVariance, shotVariance);
				bulletConfiguration.Initialize(Globals.rotate(Vector2.left, varianceAngle));
			}
			shotTimer.ResetAndStart();
		}
	}
}
