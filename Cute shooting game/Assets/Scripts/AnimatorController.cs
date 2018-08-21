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

    private void Update()
    {
        animator.SetFloat("xSpeed", Input.GetAxis("Horizontal"));
        animator.SetFloat("ySpeed", Input.GetAxis("Vertical"));
        //float moveMultiplier = Mathf.Clamp(movement.rigidBody.velocity.x + movement.rigidBody.velocity.z, -2.8f, 2.8f);
        //animator.SetFloat(AnimatorValues.SpeedMultiplier, moveMultiplier);
        //animator.speed = moveMultiplier;
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