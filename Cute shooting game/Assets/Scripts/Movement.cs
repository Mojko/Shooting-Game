using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour 
{
	public bool IsGrounded { get; private set; }
	
	public Rigidbody rigidBody;
	public float moveSpeed;
	public float jumpSpeed;

    private float maxSpeed;
    private float minSpeed;
	private Vector3 velocity;

    private bool canMove;

    private void Start()
    {
        this.minSpeed = -this.moveSpeed;
        this.maxSpeed = this.moveSpeed;
        this.canMove = true;
    }

	private void Update()
	{
		this.CheckForGround();
	}

    public void Push(Vector3 direction, int force)
    {
        this.moveSpeed = this.minSpeed;

        this.Move(-direction.x, -direction.z, this.moveSpeed * force);
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
        /*this.rigidBody.velocity = new Vector3(
			xSpeed * moveSpeed * Time.deltaTime, 
			this.rigidBody.velocity.y, 
			zSpeed * moveSpeed * Time.deltaTime
		);*/
        if(this.moveSpeed < this.maxSpeed)
        {
            this.moveSpeed += this.maxSpeed / 25;
        }

        this.Move(xSpeed, zSpeed, this.moveSpeed);
	}

    public void Move(IsometricVector3 direction)
    {
        this.Move(direction.x, direction.z);
    }

    private void Move(float xSpeed, float zSpeed, float moveSpeed)
    {
        this.rigidBody.velocity = Vector3.zero;

        Vector3 speed = new Vector3(
            xSpeed * moveSpeed * Time.deltaTime
            , this.rigidBody.velocity.y
            , zSpeed * moveSpeed * Time.deltaTime
        );

        this.rigidBody.velocity += speed;

        this.velocity = this.rigidBody.velocity;
    }

    public void Move(Vector3 direction)
    {
        this.Move(direction.x, direction.z);
    }

    public void Jump()
	{
		this.rigidBody.velocity += new Vector3(0, jumpSpeed, 0);
	}
	
	public void Rotate(Vector3 towards)
	{
		Vector3 movement = new Vector3(towards.x, 0, towards.z);
		
		if (movement != Vector3.zero)
		{
			this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.2f);
		}
	}

	public void Rotate(float xAxis, float zAxis)
	{
		this.Rotate(new Vector3(xAxis, 0, zAxis));
	}
	
	public static void FollowObject(GameObject me, GameObject target, Vector3 offset, float smoothing)
	{
        Vector3 targetPosition = new Vector3(target.transform.position.x - offset.x, target.transform.position.y - offset.y, target.transform.position.z - offset.z);
        me.transform.position = Vector3.Lerp(me.transform.position, targetPosition, smoothing);
	}

    public void DisableMovement()
    {
        this.canMove = false;
        //this.moveSpeed = 0;
    }

    public void EnableMovement()
    {
        this.canMove = true;
    }
}

public static class PushPower
{
    public const int STRONG = 5;
    public const int MILD = 3;
    public const int WEAK = 1;
}