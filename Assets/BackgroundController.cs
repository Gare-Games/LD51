using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.classes;

public class BackgroundController : MonoBehaviour
{
	public GameObject backgroundLeft;
	public GameObject backgroundMid;
	public GameObject backgroundRight;


	public float leftEnd;
	public float rightStart;

	public float speed = 1.0f;

	// Start is called before the first frame update
	void Start()
	{
		Globals.BackgroundController = this;
	}

	// Update is called once per frame
	void Update()
	{
		if (Globals.BackgroundController == null)
		{
			Globals.BackgroundController = this;
		}
		float intervalSpeed = speed * Time.deltaTime;

		backgroundLeft.transform.position = new Vector3(backgroundLeft.transform.position.x - intervalSpeed, 0, 0);
		backgroundMid.transform.position = new Vector3(backgroundMid.transform.position.x - intervalSpeed, 0, 0);
		backgroundRight.transform.position = new Vector3(backgroundRight.transform.position.x - intervalSpeed, 0, 0);

		if (backgroundLeft != null)
		{
			if (backgroundLeft.transform.position.x < leftEnd)
				backgroundLeft.transform.position = new Vector3(rightStart, 0, 0);
			if (backgroundMid.transform.position.x < leftEnd)
				backgroundMid.transform.position = new Vector3(rightStart, 0, 0);
			if (backgroundRight.transform.position.x < leftEnd)
				backgroundRight.transform.position = new Vector3(rightStart, 0, 0);
		}
	}

	public void ResetGame()
	{
		backgroundLeft.transform.position = new Vector3(-27.656f, 0, 0);
		backgroundMid.transform.position = new Vector3(0, 0, 0);
		backgroundRight.transform.position = new Vector3(27.656f, 0, 0);
	}
}
