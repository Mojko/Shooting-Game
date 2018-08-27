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
        this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
        movement.Move(transform.forward);
	}
}
