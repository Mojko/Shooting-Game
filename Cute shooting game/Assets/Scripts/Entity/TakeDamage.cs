using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float health;

    public void Hurt(float amount)
    {
        this.health -= amount;
        if(this.rigidBody != null)
        {
            this.rigidBody.AddForce(-transform.forward * 10000);
        }
    }
}
