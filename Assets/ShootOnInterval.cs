using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class ShootOnInterval : MonoBehaviour
{
	public Timer shotTimer;
	public GameObject projectileToSpawn;
	public float shotVariance = 4.5f;
	public Globals.Direction direction = Globals.Direction.left;


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
			Globals.GameController.PlayEnemyShootSound();
			GameObject bulletObj = Instantiate(projectileToSpawn, gameObject.transform.position, Quaternion.identity);
			BulletConfiguration bulletConfiguration = bulletObj.GetComponent<BulletConfiguration>();
			if (bulletConfiguration != null)
			{
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
					case Globals.Direction.upleft:
						startDirection = Globals.rotate(Vector2.left, -15.0f);
						break;
					case Globals.Direction.downleft:
						startDirection = Globals.rotate(Vector2.left, 15.0f);
						break;
					default:
						startDirection = Vector2.left;
						break;
				}
				float varianceAngle = Random.Range(-shotVariance, shotVariance);
				Vector2 shotDirection = Globals.rotate(startDirection, varianceAngle);
				bulletConfiguration.Initialize(shotDirection);
			}
			shotTimer.ResetAndStart();
		}
	}
}
