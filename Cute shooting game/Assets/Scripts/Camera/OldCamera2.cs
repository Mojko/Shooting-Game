using UnityEngine;
using System.Collections;

public class OldCamera2 : MonoBehaviour
{
    public Transform target;
    public CameraSettings cameraSettings;

    private Vector3 idealPosition;
    private Quaternion idealAngle;
    private float idealDistance;
    private Vector3 extra;

    private bool test;

    private float currentX;
    private float currentY;
    private float zoom;
    private readonly float startZoom = 1.25f;

    private void Start()
    {
        this.zoom = this.startZoom;
        this.idealPosition = this.transform.position;
    }

    private void Update()
    {
        Vector3 dir = new Vector3(0f, 4f, -12f);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        this.idealPosition = this.target.position + rotation * dir * zoom;
        this.idealAngle = rotation;
        this.idealDistance = Vector3.Distance(this.idealPosition, this.target.position) - 0.5f;

        if (!Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Horizontal");
            return;
        }

        currentX += Input.GetAxis("Mouse X") * cameraSettings.sensitivty;
        currentY -= Input.GetAxis("Mouse Y") * cameraSettings.sensitivty;
        currentY = Mathf.Clamp(currentY, -25f, 75f);
    }

    private void LateUpdate()
    {
        RaycastHit[] hits = new RaycastHit[8];

        bool left = this.HasHit(this.transform.position, -this.transform.right, out hits[0]);
        bool up = this.HasHit(this.transform.position, this.transform.up, out hits[1]);
        bool right = this.HasHit(this.transform.position, this.transform.right, out hits[2]);
        bool down = this.HasHit(this.transform.position, -this.transform.up, out hits[3]);
        bool forward = this.HasHit(this.transform.position, this.transform.forward, out hits[4]);
        bool back = this.HasHit(this.transform.position, -this.transform.forward, out hits[5]);
        bool target = this.HasHit(this.target.position, this.GetDirection(this.transform.position, this.target.position), out hits[6], Vector3.Distance(this.transform.position, this.target.position));
        bool ideal = this.HasHit(this.idealPosition, this.GetDirection(this.target.position, this.idealPosition), out hits[7], Vector3.Distance(this.idealPosition, this.target.position));


        //if (ideal)
        //{
        //    Debug.Log(hits[7].transform.name);
        //    if (hits[7].transform.name == "Player")
        //    {
        //        this.transform.position = this.idealPosition;
        //    }
        //}

        //if (target)
        //{
        //    if (hits[6].transform.name != this.name)
        //    {
        //        Vector3 dir = new Vector3(0f, 4f, -12f);
        //        this.transform.position = Vector3.Lerp(hits[6].point, this.target.transform.position, 0.2f);
        //    }
        //    else
        //    {
        //        test = true;
        //    }
        //}

        this.transform.LookAt(this.target.position);
    }

    private Vector3 GetDirection(Vector3 vec1, Vector3 vec2)
    {
        return vec1 - vec2;
    }

    //private bool HasHit(Vector3 me, Vector3 target, out RaycastHit hit)
    //{
    //    Vector3 direction = this.GetDirection(me, target);
    //    Ray ray = new Ray(target, direction);
    //    bool hasHit = Physics.Raycast(ray, out hit);
    //    Debug.DrawRay(ray.origin, ray.direction * 5f, Color.green);
    //    return hasHit;
    //}

    private bool HasHit(Vector3 origin, Vector3 direction, out RaycastHit hit, float distance = 1f)
    {
        Ray ray = new Ray(origin, direction);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
        bool hasHit = Physics.Raycast(ray.origin, ray.direction, out hit, distance);
        return hasHit;
    }
}