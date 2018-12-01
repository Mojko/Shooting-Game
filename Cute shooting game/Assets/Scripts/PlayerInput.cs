using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public Movement movement;
    public Animator animator;
    public EquipGun gunEquipper;
    public ScreenShake screenShake;
    public LookAtMouse lookAtMouse;

    private ThirdPersonCamera thirdPersonCamera;
    public Transform chest;

    private void Start()
    {
        this.thirdPersonCamera = Camera.main.GetComponent<ThirdPersonCamera>();
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Quaternion rotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        this.movement.Move(rotation * new Vector3(xAxis, 0, zAxis));

        if (Input.GetMouseButton(1))
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.eulerAngles.x
                , this.thirdPersonCamera.transform.rotation.eulerAngles.y
                , this.transform.rotation.eulerAngles.z
            ));
        }
        else
        {
            this.movement.Rotate(rotation * new Vector3(xAxis, 0, zAxis), 0.1f);
        }

        this.animator.SetFloat("xSpeed", xAxis);
        this.animator.SetFloat("zSpeed", zAxis);

        if (Input.GetKey(KeyCode.Space))
        {
            movement.Jump();
        }
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            this.LookAtMouse(-24f);
        }

        if (Input.GetMouseButton(2))
        {
            this.Aim();
        }
        else
        {
            this.StopAim();
        }
    }

    private void Update()
    {
        bool canShoot = (this.gunEquipper.gun.shootType == ShootType.Click)
            ? Input.GetMouseButtonDown(0)
            : Input.GetMouseButton(0);

        if (this.gunEquipper.gun.isOneHanded)
        {
            this.animator.SetTrigger("OneHanded");
        }
        else
        {
            this.animator.SetTrigger("TwoHanded");
        }

        if (canShoot || Input.GetKey(KeyCode.LeftAlt))
        {
            this.Shoot();
        }
        else
        {
            this.StopShoot();
        }
    }

    private void Aim()
    {
        this.LookAtMouse();

        this.thirdPersonCamera.SetCameraState(CameraState.ZoomedIn);
    }

    private void LookAtMouse(float xOffset = 0f)
    {
        if (!this.lookAtMouse.enabled)
        {
            this.lookAtMouse.Enable();
            this.animator.SetBool("FreeMoving", true);
        }

        this.chest.rotation = Quaternion.Euler(this.thirdPersonCamera.transform.rotation.eulerAngles.x + xOffset, this.thirdPersonCamera.transform.rotation.eulerAngles.y, this.thirdPersonCamera.transform.rotation.eulerAngles.z);
    }

    private void StopLookAtMouse()
    {
        if (this.lookAtMouse.enabled)
        {
            this.lookAtMouse.Disable();
            this.animator.SetBool("FreeMoving", false);
        }
    }

    private void StopAim()
    {
        this.lookAtMouse.Disable();
        this.animator.SetBool("FreeMoving", false);
        this.thirdPersonCamera.SetCameraState(CameraState.Normal);
        this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.eulerAngles.y, 0);
    }

    private void Shoot()
    {
        this.animator.SetBool("Shoot", true);
        if (this.gunEquipper.shooter.Shoot(this.animator))
        {
            this.screenShake.Shake(this.gunEquipper.gun.power);
        }
    }

    private void StopShoot()
    {
        this.animator.SetBool("Shoot", false);
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