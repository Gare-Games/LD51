using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Assets.classes;

public class PlayerShipMovementController : MonoBehaviour
{

	public int maxSpeedUpgradeCnt = 3;
	public int maxHandlingUpgradeCnt = 8;

	public int currentSpeedUpgrade = 0;
	public int currentHandlingUpgrade = 0;

	bool bMoveUp = false;
	bool bMoveUpStarted = false;
	bool bMoveUpEnded = false;
	bool bMoveDown = false;
	bool bMoveBackwards = false;
	bool bMoveForwards = false;
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
		moveDownWarmupTimer.Interval();
		moveDownCooldownTimer.Interval();
		forwardsWarmupTimer.Interval();
		forwardsCooldownTimer.Interval();
		backwardsWarmupTimer.Interval();
		backwardsCooldownTimer.Interval();

		CollectInput();

		DoAction();
	}

	public void DoAction()
	{
		m_rigidbody2D.velocity = Vector2.zero;

		m_rigidbody2D.velocity += UpwardVelocity();
		m_rigidbody2D.velocity += DownwardVelocity();
		m_rigidbody2D.velocity += BackwardsVelocity();
		m_rigidbody2D.velocity += ForwardsVelocity();
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

	public Vector2 BackwardsVelocity()
	{
		if (bMoveBackwards)
		{
			if (!backwardsWarmupTimer.IsFinished() && backwardsWarmupTimer.HasStarted())
			{
				return Vector2.left * backwardsSpeed;
			}
			else if (backwardsWarmupTimer.IsFinished())
			{
				return Vector2.left * backwardsSpeed;
			}
		}
		if (!backwardsCooldownTimer.IsFinished() && backwardsCooldownTimer.HasStarted())
		{
			return Vector2.left * backwardsWarmUpSpeed;
		}

		return Vector2.zero;
	}

	public Vector2 ForwardsVelocity()
	{
		if (bMoveForwards)
		{
			if (!forwardsWarmupTimer.IsFinished() && forwardsWarmupTimer.HasStarted())
			{
				return Vector2.right * forwardsSpeed;
			}
			else if (forwardsWarmupTimer.IsFinished())
			{
				return Vector2.right * forwardsSpeed;
			}
		}
		if (!forwardsCooldownTimer.IsFinished() && forwardsCooldownTimer.HasStarted())
		{
			return Vector2.right * forwardsWarmUpSpeed;
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

			//Left Input
			if (Keyboard.current[Key.LeftArrow].isPressed && Keyboard.current[Key.LeftArrow].wasPressedThisFrame)
			{
				bMoveBackwards = true;
				backwardsWarmupTimer.ResetAndStart();
				backwardsCooldownTimer.Reset();
			}
			else if (Keyboard.current[Key.LeftArrow].isPressed && !Keyboard.current[Key.LeftArrow].wasPressedThisFrame)
			{
			}
			else if (!Keyboard.current[Key.LeftArrow].isPressed && Keyboard.current[Key.LeftArrow].wasReleasedThisFrame)
			{
				bMoveBackwards = false;
				backwardsWarmupTimer.Reset();
				backwardsCooldownTimer.ResetAndStart();
			}

			//Right Input
			if (Keyboard.current[Key.RightArrow].isPressed && Keyboard.current[Key.RightArrow].wasPressedThisFrame)
			{
				bMoveForwards = true;
				forwardsWarmupTimer.ResetAndStart();
				forwardsCooldownTimer.Reset();
			}
			else if (Keyboard.current[Key.RightArrow].isPressed && !Keyboard.current[Key.RightArrow].wasPressedThisFrame)
			{
			}
			else if (!Keyboard.current[Key.RightArrow].isPressed && Keyboard.current[Key.RightArrow].wasReleasedThisFrame)
			{
				bMoveForwards = false;
				forwardsWarmupTimer.Reset();
				forwardsCooldownTimer.ResetAndStart();
			}

		}
	}

	public void UpgradeSpeed()
	{
		currentSpeedUpgrade++;

		verticalSpeed += 0.45f;
		verticalWarmUpSpeed += 0.15f;

		forwardsSpeed += 0.45f;
		forwardsWarmUpSpeed += 0.15f;

		backwardsSpeed += 0.15f;
		backwardsWarmUpSpeed += 0.09f;

		if (currentSpeedUpgrade >= maxSpeedUpgradeCnt)
		{
			//REMOVE speed upgrade from cards.
			Globals.GameController.upgradeSelectorController.playerUpgradeController.RemoveUpgradeConfig("movespeed");
		}
	}

	public void UpgradeHandling()
	{
		currentHandlingUpgrade++;

		moveUpWarmupTimer.frequency -= 0.05f;
		moveUpCooldownTimer.frequency -= 0.05f;
		moveDownWarmupTimer.frequency -= 0.05f;
		moveDownCooldownTimer.frequency -= 0.05f;
		forwardsWarmupTimer.frequency -= 0.05f;
		forwardsCooldownTimer.frequency -= 0.05f;
		backwardsWarmupTimer.frequency -= 0.05f;
		backwardsCooldownTimer.frequency -= 0.05f;

		if (currentHandlingUpgrade >= maxHandlingUpgradeCnt)
		{
			// Remove handling from upgrade list when max reached.
			Globals.GameController.upgradeSelectorController.playerUpgradeController.RemoveUpgradeConfig("shipwheel");
		}
	}
}
