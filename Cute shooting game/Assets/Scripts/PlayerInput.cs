using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Movement movement;
    public EquipGun gunEquipper;
    public AnimatorController animator;
    public ScreenShake screenShake;

    private void FixedUpdate()
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

        movement.Move(new Vector3(xAxis, 0, zAxis));
		
        if (Input.GetKey(KeyCode.Space) && movement.IsGrounded)
        {
            movement.Jump();
        }
    }

    private void ShootInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (this.gunEquipper.shooter.Shoot())
            {
                this.screenShake.Shake(this.gunEquipper.gun.power);
            } 
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