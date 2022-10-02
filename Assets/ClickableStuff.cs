using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ClickableStuff : MonoBehaviour
{

	public string urlToOpen;
	public Texture2D hoverCursor;
	public bool cursorIsIn = false;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

	private void OnMouseEnter()
	{
		Cursor.SetCursor(hoverCursor, Vector3.zero, CursorMode.ForceSoftware);
	}

	private void OnMouseExit()
	{
		Cursor.SetCursor(null, Vector3.zero, CursorMode.ForceSoftware);
	}

	private void OnMouseUpAsButton()
	{
		ActionToTake();
	}

	public void ActionToTake()
	{
		Application.OpenURL(urlToOpen);
	}
}
