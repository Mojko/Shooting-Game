using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour, IMovement
{
    public Movement movement;
    public Animator animator;

	private void Start ()
	{
		
	}
	
	private void Update ()
	{
		
	}

    public void Move(Vector3 direction)
    {
        this.movement.Move(direction);
        this.animator.SetFloat("xSpeed", direction.x);
        this.animator.SetFloat("zSpeed", direction.z);
    }

    public void Rotate(Vector3 direction)
    {
        this.movement.Rotate(direction);
    }

    public void Push(Vector3 direction, PushPower force, float? distance)
    {
        this.movement.Push(direction, force, distance);
    }
}