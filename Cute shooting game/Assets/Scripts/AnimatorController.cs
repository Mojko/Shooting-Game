using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class AnimatorController : MonoBehaviour
{
	public Animator animator;
	public Movement movement;

	private delegate void StopAnimationDelegate();
	
	private void Update ()
	{
		float moveMultiplier = Mathf.Clamp(Mathf.Abs(movement.rigidBody.velocity.x) + Mathf.Abs(movement.rigidBody.velocity.z), 0, 2.8f);
		animator.SetFloat(AnimatorValues.SpeedMultiplier, moveMultiplier);
	}

	public void StartAim()
	{
		animator.SetBool(AnimatorValues.AimTrigger, true);
		
	}

	public void StopAim()
	{
		animator.SetBool(AnimatorValues.AimTrigger, false);
	}
}

public static class AnimatorValues
{
	public const string SpeedMultiplier = "speed";
	public const string AimTrigger = "Aim";
	public const string Shoot = "Shoot";
}

public enum AnimatorTypes
{
	Bool,
	Float
}