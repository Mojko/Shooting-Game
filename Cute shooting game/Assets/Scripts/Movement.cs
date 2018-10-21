using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MovementBase
{
	public bool IsGrounded { get; set; }

	public Rigidbody rigidBody;
	public float movespeed;
	public float jumpspeed;
	public float acceleration;

	public override void Move(Vector3 direction)
	{
        this.rigidBody.MovePosition(this.transform.position + direction * movespeed * Time.deltaTime);
	}

	public void Jump()
	{
        
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

	public static void FollowObject(GameObject me, GameObject target, Vector3 offset, float smoothing, float distance)
	{
        Vector3 newTarget = me.transform.position;

        if(Vector3.Distance(me.transform.position, target.transform.position) > distance)
        {
            newTarget = target.transform.position - offset;//newTarget = new Vector3(target.transform.position.x - offset.x, target.transform.position.y - offset.y, target.transform.position.z - offset.z);
        }

        me.transform.position = Vector3.Lerp(me.transform.position, newTarget, 0.05f);
    }

	/*
    public bool IsGrounded { get; private set; }

    public Rigidbody rigidBody;
    public float moveSpeed;
    public float jumpSpeed;
    public float acceleration;
    public float knockbackTimer;

    private float knockbackTimerOriginal;
    private float maxSpeed;
    private float minSpeed;
    private Vector3 velocity;

    private bool canMove;

    private void Start()
    {
        this.minSpeed = -this.moveSpeed;
        this.maxSpeed = this.moveSpeed;
        this.canMove = true;
        this.knockbackTimerOriginal = this.knockbackTimer;
    }

    private void Update()
    {
        this.CheckForGround();
        if (this.knockbackTimer > 0)
        {
            this.knockbackTimer -= 1 * Time.deltaTime;

        }
        else
        {
            
        }
    }

    public void Push(Vector3 direction, PushPower force)
    {
        this.moveSpeed = this.minSpeed * (int)force;
        this.Move(-direction.x, -direction.z, this.moveSpeed * (int)force);
        this.knockbackTimer = this.knockbackTimerOriginal;
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
        if (this.moveSpeed < this.maxSpeed)
        {
            this.moveSpeed += this.acceleration;
            this.moveSpeed = Mathf.Clamp(this.moveSpeed, this.minSpeed, this.maxSpeed);
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

        Vector3 speed = new Vector3(xSpeed * moveSpeed * Time.deltaTime, this.rigidBody.velocity.y, zSpeed * moveSpeed * Time.deltaTime);

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
    }*/
}

/*this.rigidBody.velocity = new Vector3(
            xSpeed * moveSpeed * Time.deltaTime, 
            this.rigidBody.velocity.y, 
            zSpeed * moveSpeed * Time.deltaTime
        );*/
/*
public static class PushPower
{
    public const int STRONG = 5;
    public const int MILD = 3;
    public const int WEAK = 1;
}*/

public enum PushPower
{
	STRONG = 10,
	MILD = 5,
	WEAK = 3
}