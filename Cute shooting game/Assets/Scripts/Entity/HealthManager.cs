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

    private bool isHurt;

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
        this.isHurt = true;

        if (this.movement != null)
        {
            float distance = Vector3.Distance(this.transform.position, source.transform.position);
            this.movement.Push(source.transform.forward, this.pushPower, distance);
            this.movement.enabled = false;

            this.hurtTimer.StartTimer(() =>
            {
                this.movement.enabled = true;
                this.isHurt = false;
            }, almostFinish: () =>
            {
                this.ResetColor();
            });
        }

        if(this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public bool IsHurt()
    {
        return this.isHurt;
    }
}
