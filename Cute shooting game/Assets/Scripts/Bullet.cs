using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float speed;
    public GameObject onDeathParticle;

    [HideInInspector] public Shooter source;

    private bool slowOverTime;
    private float maxSpeed;

    private void Start()
    {
        this.maxSpeed = this.speed;
    }

    private void FixedUpdate()
    {
        this.rigidBody.MovePosition(this.transform.position + this.transform.forward * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (slowOverTime)
        {
            this.speed = SpeedHelper.Slow(this.speed, this.maxSpeed, 0.05f);

            if (this.speed <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.name == this.name)
        {
            return;
        }

        Instantiate(this.onDeathParticle, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void SetSlowOverTime(bool slowOverTime)
    {
        this.slowOverTime = slowOverTime;
    }
}


/* Vector3 newRot = new Vector3(0, direction.y, 0);
        if (newRot != Vector3.zero)
        {
            //this.transform.rotation = Quaternion.LookRotation(newRot);
            //this.transform.Rotate(new Vector3(0, 0, bulletOffset));
        };      //this.transform.Translate(new Vector3(this.direction.x, 0, this.direction.z));
        //Vector3 offsetDirection = new Vector3(direction.x + 0.5f, direction.y, direction.z);
        */