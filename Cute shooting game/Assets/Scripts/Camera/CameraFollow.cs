using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour, IOffset
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

	public void SetOffset()
	{
		this.offset = new Vector3(-this.transform.position.x, -this.transform.position.y, -this.transform.position.z);
	}
}