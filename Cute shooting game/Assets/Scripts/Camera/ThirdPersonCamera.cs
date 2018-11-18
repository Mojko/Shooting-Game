using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour 
{
    public Transform target;
    public CameraSettings cameraSettings;

    private Camera myCamera;
    private float maxDistance = 10.0f;
    private float xRot;
    private float yRot;
    private float yStart;
    private Vector3 dollyPosition;
    private float distance;
    private CameraState cameraState;

    private void Awake()
    {
        this.yStart = Input.GetAxis("Mouse Y") * cameraSettings.sensitivty;
        distance = maxDistance;
        this.myCamera = this.GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 dir = new Vector3(0f, 0.5f, -1.25f);
        Quaternion rotation = Quaternion.Euler(yRot, xRot, 0);

        if (this.cameraState == CameraState.ZoomedIn)
        {
            Vector3 offset = new Vector3(2.75f, 0.5f, -3.5f);

            this.dollyPosition = this.target.position + rotation * offset;
            this.transform.rotation = rotation;
        }
        else
        {
            this.dollyPosition = this.target.position + rotation * dir * this.distance;
        }

        Vector3 point;
        bool hit = RayCastHelper.ShootLine(this.target.transform.position, this.dollyPosition, out point);

        if (hit)
        {
            this.dollyPosition = point;
        }

        transform.position = this.dollyPosition;

        if(this.cameraState == CameraState.Normal)
        {
            this.transform.LookAt(this.target.transform.position);
        }

        if (Input.GetMouseButton(1) || this.cameraState == CameraState.ZoomedIn)
        {
            xRot += Input.GetAxis("Mouse X") * cameraSettings.sensitivty;
            yRot -= Input.GetAxis("Mouse Y") * cameraSettings.sensitivty;
            yRot = Mathf.Clamp(yRot, -40f, 45f);
        }
        else if(!Input.GetMouseButton(1) && this.cameraState == CameraState.Normal)
        {
            xRot += Input.GetAxis("Horizontal");
            yRot = Mathf.Lerp(yRot, this.yStart, 0.25f);
        }
    }

    public void SetCameraState(CameraState state)
    {
        this.cameraState = state;
    }
}