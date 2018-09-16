using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : ColorManipulator
{
    public Movement movement;
    public float health;
    public Timer timer;
    public PushPower pushPower;

    public void Hurt(DealDamage source, float amount)
    {
        this.health -= amount;
        this.ChangeColor();
        if (this.movement != null)
        {
            float distance = Vector3.Distance(this.transform.position, source.transform.position);
            this.movement.Push(source.transform.forward, this.pushPower, distance);
            this.movement.enabled = false;

            
            this.timer.Initilize(() =>
            {
                this.movement.enabled = true;
                this.ResetColor();
            });
        }
    }
}
