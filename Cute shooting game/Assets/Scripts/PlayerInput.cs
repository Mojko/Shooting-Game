using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	
	public Movement movement;
	public ShootComponent shootComponent;
	public AnimatorController animatorController;
	
	private void FixedUpdate ()
	{
		float xAxis = Input.GetAxis("Horizontal");
		float zAxis = Input.GetAxis("Vertical");

		movement.Move(xAxis, zAxis);

		float xAxisRaw = Input.GetAxisRaw("Horizontal");
		float zAxisRaw = Input.GetAxisRaw("Vertical");
		
		movement.Rotate(xAxisRaw, zAxisRaw);

		if (Input.GetKey(KeyCode.Space) && movement.IsGrounded)
		{
			movement.Jump();
		}

		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			Debug.Log("Testing");
			shootComponent.Shoot();
			animatorController.StartAim();
		}
	}
}
