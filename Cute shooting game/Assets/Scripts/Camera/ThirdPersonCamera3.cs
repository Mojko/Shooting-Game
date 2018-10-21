using UnityEngine;
using System.Collections;

public class ThirdPersonCamera3 : MonoBehaviour 
{
    [SerializeField] private float minDistance = 2.0f;
    [SerializeField] private float maxDistance = 10.0f;
    [SerializeField] private float smooth = 5.0f;

    private float currentX;
    private float currentY;

    public Transform target;
    public CameraSettings cameraSettings;

    private Vector3 dollyDir;
    private float distance;

    private void Awake()
    {
        //distance = (transform.position - this.target.position).magnitude;
        distance = 8f;
    }

    private void Update()
    {
        Vector3 dir = new Vector3(1f, 1f, 1f);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        dollyDir = this.target.position + rotation * dir * distance;

        RaycastHit hit;
        if (Physics.Linecast(target.transform.position, dollyDir, out hit))
        {
            Debug.Log("Who's the hit: " + hit.transform.name);
            distance = Mathf.Clamp(hit.distance, 0.25f, 8f);
        }


        transform.position = dollyDir;

        this.transform.LookAt(this.target.position);

        if (!Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Horizontal");
            return;
        }

        currentX += Input.GetAxis("Mouse X") * cameraSettings.sensitivty;
        currentY -= Input.GetAxis("Mouse Y") * cameraSettings.sensitivty;
        currentY = Mathf.Clamp(currentY, -25f, 75f);
    }
}