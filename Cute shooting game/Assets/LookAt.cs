using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour 
{
    public Transform target;

    private void LateUpdate()
    {
        this.transform.LookAt(new Vector3(this.target.position.x, this.target.position.y, this.target.position.z));
    }
}