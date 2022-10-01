using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnWhenPastThisPoint : MonoBehaviour
{
	public float leftBorder = -7.0f;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x < leftBorder)
			Destroy(gameObject);
	}
}
