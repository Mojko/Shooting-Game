using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	public bool IsGrounded { get; private set; }
	
	public Rigidbody rigidBody;
	public float moveSpeed;
	public float jumpSpeed;
	
	private Vector3 velocity;

	private void Update()
	{
		this.CheckForGround();
	}

	private void CheckForGround()
	{
		Ray ray = new Ray(this.transform.position, Vector3.down);
		RaycastHit hitInfo;
		if (Physics.Raycast(ray, out hitInfo, 1))
		{
			this.IsGrounded = true;
		}
		else
		{
			this.IsGrounded = false;
		}
	}
	
	public void Move(float xSpeed, float zSpeed)
	{
		this.rigidBody.velocity = new Vector3(
			xSpeed * moveSpeed * Time.deltaTime, 
			this.rigidBody.velocity.y, 
			zSpeed * moveSpeed * Time.deltaTime
		);

		this.velocity = this.rigidBody.velocity;
	}

	public void Jump()
	{
		this.rigidBody.velocity += new Vector3(0, jumpSpeed, 0);
	}
	
	public void Rotate(float xTowards, float zTowards)
	{
		Vector3 movement = new Vector3(xTowards, 0, zTowards);
		
		if (movement != Vector3.zero)
		{
			this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.2f);
		}
	}
	
	public static void FollowObject(GameObject me, GameObject target, Vector3 offset)
	{
		me.transform.position = new Vector3(target.transform.position.x - offset.x, target.transform.position.y - offset.y, target.transform.position.z - offset.z);
	}
}
