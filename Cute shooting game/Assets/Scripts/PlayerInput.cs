using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	
	public Movement movement;
	public EquipGun gunEquipper;
	public AnimatorController animator;
	
	private void FixedUpdate ()
	{
		this.MoveInput();
	}

	private void Update()
	{
		this.ShootInput();
	}

	private void MoveInput()
	{
		float xAxis = Input.GetAxis("Horizontal");
		float zAxis = Input.GetAxis("Vertical");

		movement.Move(xAxis, zAxis);
		
		if (Input.GetKey(KeyCode.Space) && movement.IsGrounded)
		{
			movement.Jump();
		}
	}

	private void ShootInput()
	{
		if (Input.GetMouseButton(0))
		{
			gunEquipper.gun.Shoot();
		}
	}
}




















//this.lookAtMouse.enabled = true;
/*
if (this.animatorController.animator.GetBool(AnimatorValues.AimTrigger))
{
	this.lookAtMouse.enabled = true;
}
else
{
	this.lookAtMouse.enabled = false;
	this.movement.Rotate(xAxisRaw, zAxisRaw);
}
*/