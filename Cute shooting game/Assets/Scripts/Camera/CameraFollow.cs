using UnityEngine;
using System.Collections;
using System;

public class CameraFollow : MonoBehaviour
{
	public Vector3 offset;
	
	public GameObject objectToFollow;
    [Range(0,1)]public float smoothing;
    Vector3 startPosition;

    private float currentX;
    private float currentY;

	private void Start ()
	{
        this.startPosition = this.transform.position;
	}
	
	private void Update ()
	{
        //this.transform.position = Vector3.Lerp(this.transform.position, objectToFollow.transform.position - offset, 0.2f);
        this.transform.position = objectToFollow.transform.position - offset;
        //Movement.FollowObject(this.gameObject, this.objectToFollow, this.offset, smoothing, 0);
	}

    public void Rotate(Transform target)
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        this.transform.position = target.position + Quaternion.Euler(currentY, currentX, 0) * new Vector3(0, 0, -10f);
        this.transform.LookAt(target.position);
    }

    public void SetOffset()
	{
		this.offset = new Vector3(-this.transform.position.x, -this.transform.position.y, -this.transform.position.z);
	}
}