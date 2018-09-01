using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour {

    public Movement movement;
    public GameObject target;

	private void Start ()
    {
		
	}

	private void Update ()
    {
        Vector3 targetLocation = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
        Quaternion lookRotation = Quaternion.LookRotation(targetLocation - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, 0.05f);
        //this.transform.LookAt();
        movement.Move(transform.forward);
	}
}
