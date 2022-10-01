using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipMovementController : MonoBehaviour
{
	bool bMoveUp = false;
	bool bMoveUpStarted = false;
	bool bMoveUpEnded = false;
	bool bMoveDown = false;
	bool bMoveLeft = false;
	bool bMoveRight = false;

	Rigidbody2D m_rigidbody2D;


	public float verticalWarmUpSpeed = 0.5f;
	public float verticalSpeed = 0.75f;

	public float forwardsWarmUpSpeed = 0.5f;
	public float forwardsSpeed = 0.75f;

	public float backwardsWarmUpSpeed = 0.5f;
	public float backwardsSpeed = 0.75f;


	//up
	public Timer moveUpWarmupTimer;
	public Timer moveUpCooldownTimer;

	//down
	public Timer moveDownWarmupTimer;
	public Timer moveDownCooldownTimer;

	//down
	public Timer forwardsWarmupTimer;
	public Timer forwardsCooldownTimer;

	//down
	public Timer backwardsWarmupTimer;
	public Timer backwardsCooldownTimer;


	// Start is called before the first frame update
	void Start()
	{
		m_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		moveUpWarmupTimer.Interval();
		moveUpCooldownTimer.Interval();
		CollectInput();

		DoAction();
	}

	public void DoAction()
	{
		m_rigidbody2D.velocity = Vector2.zero;

		m_rigidbody2D.velocity += UpwardVelocity();
		m_rigidbody2D.velocity += DownwardVelocity();
	}

	public Vector2 UpwardVelocity()
	{
		if (bMoveUp)
		{
			if (!moveUpWarmupTimer.IsFinished() && moveUpWarmupTimer.HasStarted())
			{
				return Vector2.up * verticalWarmUpSpeed;
			}
			else if (moveUpWarmupTimer.IsFinished())
			{
				return Vector2.up * verticalSpeed;
			}
		}
		if (!moveUpCooldownTimer.IsFinished() && moveUpCooldownTimer.HasStarted())
		{
			return Vector2.up * verticalWarmUpSpeed;
		}

		return Vector2.zero;
	}

	public Vector2 DownwardVelocity()
	{
		if (bMoveDown)
		{
			if (!moveDownWarmupTimer.IsFinished() && moveDownWarmupTimer.HasStarted())
			{
				return Vector2.down * verticalWarmUpSpeed;
			}
			else if (moveDownWarmupTimer.IsFinished())
			{
				return Vector2.down * verticalSpeed;
			}
		}
		if (!moveDownCooldownTimer.IsFinished() && moveDownCooldownTimer.HasStarted())
		{
			return Vector2.down * verticalWarmUpSpeed;
		}

		return Vector2.zero;
	}

	public void CollectInput()
	{
		if (Keyboard.current != null)
		{
			//Up Input
			if (Keyboard.current[Key.UpArrow].isPressed && Keyboard.current[Key.UpArrow].wasPressedThisFrame)
			{
				bMoveUp = true;
				moveUpWarmupTimer.ResetAndStart();
				moveUpCooldownTimer.Reset();
			}
			else if (Keyboard.current[Key.UpArrow].isPressed && !Keyboard.current[Key.UpArrow].wasPressedThisFrame)
			{
			}
			else if (!Keyboard.current[Key.UpArrow].isPressed && Keyboard.current[Key.UpArrow].wasReleasedThisFrame)
			{
				bMoveUp = false;
				moveUpWarmupTimer.Reset();
				moveUpCooldownTimer.ResetAndStart();
			}

			//Down Input
			if (Keyboard.current[Key.DownArrow].isPressed && Keyboard.current[Key.DownArrow].wasPressedThisFrame)
			{
				bMoveDown = true;
				moveDownWarmupTimer.ResetAndStart();
				moveDownCooldownTimer.Reset();
			}
			else if (Keyboard.current[Key.DownArrow].isPressed && !Keyboard.current[Key.DownArrow].wasPressedThisFrame)
			{
			}
			else if (!Keyboard.current[Key.DownArrow].isPressed && Keyboard.current[Key.DownArrow].wasReleasedThisFrame)
			{
				bMoveDown = false;
				moveDownWarmupTimer.Reset();
				moveDownCooldownTimer.ResetAndStart();
			}
		}

		if (Keyboard.current[Key.Digit1].isPressed)
		{
			Debug.Log("1");
		}
		if (Keyboard.current[Key.Digit2].isPressed)
		{
			Debug.Log("2");
		}
		if (Keyboard.current[Key.Digit3].isPressed)
		{
			Debug.Log("3");
		}
		if (Keyboard.current[Key.Digit4].isPressed)
		{
			Debug.Log("4");
		}
		if (Keyboard.current[Key.LeftCtrl].isPressed)
		{
			Debug.Log("LeftCtrl");
		}
		if (Keyboard.current[Key.Space].isPressed)
		{
			Debug.Log("Space");
		}
	}
}
