using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public MoveTowards moveTowards;
    public Timer timer;
    public float health;

    public void Hurt(float amount)
    {
        this.health -= amount;
        if(this.moveTowards != null)
        {
            this.timer.Initilize();
            this.moveTowards.movement.Push(-transform.forward, PushPower.WEAK);
            this.moveTowards.enabled = false;
        }
    }

    private void Update()
    {
        if (this.timer.IsFinished())
        {
            this.moveTowards.enabled = true;
        }
    }
}
