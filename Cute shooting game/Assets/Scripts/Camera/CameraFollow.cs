using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Vector3 offset;
	
	public GameObject objectToFollow;
	
	private void Start ()
	{
	}
	
	private void Update ()
	{
		Movement.FollowObject(this.gameObject, this.objectToFollow, this.offset);
	}

	public void SetOffset(Vector3 offset)
	{
		this.offset = new Vector3(-offset.x, -offset.y, -offset.z);
	}
}