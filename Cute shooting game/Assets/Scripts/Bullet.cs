using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rigidBody;
    public int speed;
	
    //private Vector3 direction;

    public void CreateBullet(Transform entity, float directionOffset = 0)
    {
        //this.direction = direction;
        this.transform.Rotate(0, entity.eulerAngles.y + directionOffset, 0);
    }

    private void Update()
    {
       /* Vector3 newRot = new Vector3(0, direction.y, 0);
        if (newRot != Vector3.zero)
        {
            //this.transform.rotation = Quaternion.LookRotation(newRot);
            //this.transform.Rotate(new Vector3(0, 0, bulletOffset));
        };		//this.transform.Translate(new Vector3(this.direction.x, 0, this.direction.z));
        //Vector3 offsetDirection = new Vector3(direction.x + 0.5f, direction.y, direction.z);
        */

        this.rigidBody.velocity = transform.forward * speed * Time.deltaTime;
    }
}
