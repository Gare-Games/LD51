using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWhenPastThisPointRight : MonoBehaviour
{
	public float rightBorder = -8.63f;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x >= rightBorder)
			Destroy(gameObject);
	}
}
