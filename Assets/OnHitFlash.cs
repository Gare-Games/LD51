using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitFlash : MonoBehaviour
{
	public SpriteRenderer sprite;
	public Color color = Color.white;
	private Material material;
	private const string SHADER_COLOR_NAME = "_Color";


	// Start is called before the first frame update
	void Start()
	{
		material = sprite.material;
	}

	private IEnumerator FlashColor()
	{
		SetColor(color);
		yield return new WaitForSeconds(0.1f);
		ClearColor();
	}

	private void SetColor(Color color)
	{
		material.SetColor(SHADER_COLOR_NAME, color);
	}

	private void ClearColor()
	{
		material.SetColor(SHADER_COLOR_NAME, new Color(1, 1, 1, 0));
	}

	public void TriggerFlash()
	{ 
		StartCoroutine(FlashColor());
	}
}
