using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Movement movement;
    public Animator animator;
    public EquipGun gunEquipper;
    public ScreenShake screenShake;

    private void FixedUpdate()
    {
        this.MoveInput();
    }

    private void Update()
    {
        this.ShootInput();

        if (Input.GetMouseButton(2))
        {
            Camera.main.GetComponent<CameraFollow>().Rotate(this.transform);
        }
    }

    private void MoveInput()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        this.movement.Move(new Vector3(xAxis, 0, zAxis));
        this.movement.Rotate(new Vector3(xAxis, 0, zAxis));
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