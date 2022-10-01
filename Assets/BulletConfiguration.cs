using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletConfiguration : MonoBehaviour
{

	private Rigidbody2D m_rigidbody2D;

	public float speed = 1.0f;

	// Start is called before the first frame update
	void Start()
	{
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Initialize()
	{
		if (m_rigidbody2D == null) m_rigidbody2D = GetComponent<Rigidbody2D>();
		m_rigidbody2D.velocity = Vector2.right * speed;
	}
}
