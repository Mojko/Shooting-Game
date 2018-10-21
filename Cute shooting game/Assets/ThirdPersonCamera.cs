using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour 
{
    public Transform target;
    public CameraSettings cameraSettings;

    public Vector3 realPosition;
    private bool zoomed;

    public GameObject visualization;

    public Vector3 idealPosition;

    private float currentX;
    private float currentY;
    public float zoom;
    private readonly float startZoom = 1.25f;

    private void Start()
    {
        this.zoom = this.startZoom;
    }

    private void Update()
    {
        //zoom -= Input.GetAxis("Mouse ScrollWheel");

        if (!Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Horizontal");
            return;
        }

        currentX += Input.GetAxis("Mouse X") * cameraSettings.sensitivty;
        currentY -= Input.GetAxis("Mouse Y") * cameraSettings.sensitivty;
        currentY = Mathf.Clamp(currentY, -25f, 75f);
    }

    private void LateUpdate ()
	{
        Vector3 dir = new Vector3(0f, 7f, -12f);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        this.idealPosition = target.position + rotation * dir * zoom;
        this.transform.LookAt(target.position);

        Vector3 direction = this.GetDirection(this.transform.position, this.target.transform.position);
        Ray ray = new Ray(this.target.transform.position, direction);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit)
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.name != this.name)
            {
                this.ZoomIn();
            }
        }



        Debug.DrawRay(this.target.transform.position, ray.direction * 100f, Color.red);
    }

    private void ZoomIn()
    {
        if(this.zoom > 0)
        {
            this.zoom -= 0.01f;
            zoomed = true;
        }
    }

    private void ZoomOut()
    {
        if(this.zoom < 1.25f)
        {
            this.zoom += 0.01f;
        }
    }

    private Vector3 GetDirection(Vector3 vec1, Vector3 vec2)
    {
        return vec1 - vec2;
    }

    private bool HasHit(Vector3 me, Vector3 target, out RaycastHit hit)
    {
        Vector3 direction = this.GetDirection(me, target);
        Ray ray = new Ray(target, direction);
        bool hasHit = Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.green);
        return hasHit;
    }
}