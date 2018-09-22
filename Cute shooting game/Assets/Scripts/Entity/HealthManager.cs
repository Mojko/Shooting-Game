using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : ColorManipulator
{
    public MovementBase movement;
    public float health;
    public Timer hurtTimer;
    public PushPower pushPower;

    [HideInInspector] public GameObject source;

    public void Hurt(DealDamage source, float amount)
    {
        this.health -= amount;

        this.source = source.gameObject;

        if (source.IsProjectile())
        {
            this.source = source.GetComponent<Bullet>().source.gameObject;
        }

        this.ChangeColor();
        if (this.movement != null)
        {
            float distance = Vector3.Distance(this.transform.position, source.transform.position);
            this.movement.Push(source.transform.forward, this.pushPower, distance);
            this.movement.enabled = false;

            
            this.hurtTimer.Initilize(() =>
            {
                this.movement.enabled = true;
                this.ResetColor();
            });
        }
    }

    public bool IsHurt()
    {
        return this.source != null;
    }
}
