using UnityEngine;
using System.Collections;

public class ThirdPersonCamera3 : MonoBehaviour 
{
    [SerializeField] private float minDistance = 2.0f;
    [SerializeField] private float maxDistance = 10.0f;
    [SerializeField] private float smooth = 5.0f;

    private float currentX;
    private float currentY;
    private float startCurrentY;

    public Transform target;
    public CameraSettings cameraSettings;

    private Vector3 dollyDir;
    private float distance;

    private bool finished;

    public GameObject visualization;

    private void Awake()
    {
        this.startCurrentY = Input.GetAxis("Mouse Y") * cameraSettings.sensitivty;
        //distance = (transform.position - this.target.position).magnitude;
        distance = 8f;
    }

    private void Update()
    {
        Vector3 dir = new Vector3(0f, 0.75f, -1.25f);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        dollyDir = this.target.position + rotation * dir * distance;

        RaycastHit hit;
        if (Physics.Linecast(this.target.transform.position, dollyDir, out hit))
        {
            Debug.Log("Who's the hit: " + hit.transform.name + ", " + hit.distance);
            dollyDir = hit.point;
            //distance = Mathf.Clamp(Vector3.Distance(hit.point, this.target.transform.position), 0.25f, 8f) - 0.25f;
            //distance = Mathf.Clamp(hit.distance, 0.25f, 8f);
            this.visualization.transform.position = hit.point;
        }


        transform.position = dollyDir;

        this.transform.LookAt(this.target.position);

        if (!Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Horizontal");
            currentY = Mathf.Lerp(currentY, this.startCurrentY, 0.25f);
            return;
        }

        currentX += Input.GetAxis("Mouse X") * cameraSettings.sensitivty;
        currentY -= Input.GetAxis("Mouse Y") * cameraSettings.sensitivty;
        currentY = Mathf.Clamp(currentY, -25f, 45f);
    }
}