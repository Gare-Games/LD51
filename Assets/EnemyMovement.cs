using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 1.0f;
	public float idlingSpeed = 0.0f;

	private bool bFacingLeft = true;


	private Rigidbody2D m_rigidBody2D;
	// Start is called before the first frame update
	void Start()
	{
		m_rigidBody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (bFacingLeft)
			m_rigidBody2D.velocity = Vector2.left * speed;
		else
			m_rigidBody2D.velocity = Vector2.left * idlingSpeed;
	}
}
