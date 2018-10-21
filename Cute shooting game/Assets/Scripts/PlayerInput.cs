using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Movement movement;
    public Animator animator;
    public EquipGun gunEquipper;
    public ScreenShake screenShake;
    public LookAtMouse lookAtMouse;

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

        Quaternion rotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        this.movement.Move(rotation * new Vector3(xAxis, 0, zAxis));

        if (!Input.GetMouseButton(1))
        {
            this.lookAtMouse.Disable();
            this.movement.Rotate(rotation * new Vector3(xAxis, 0, zAxis));
        }
        else
        {
            if (!this.lookAtMouse.enabled)
            {
                this.lookAtMouse.Enable();
            }
        }
        
        this.animator.SetFloat("xSpeed", xAxis);
        this.animator.SetFloat("zSpeed", zAxis);

        if (Input.GetKey(KeyCode.Space) && movement.IsGrounded)
        {
            movement.Jump();
        }
    }

    private void ShootInput()
    {
        bool canShoot = (this.gunEquipper.gun.shootType == ShootType.Click) 
            ? Input.GetMouseButtonDown(0) 
            : Input.GetMouseButton(0);

        if (canShoot)
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