using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public MoveTowards moveTowards;
    public Timer timer;
    public float health;
    public Color hitColor = Color.red;
    public Renderer renderer;

    private float hitTimer;

    public void Hurt(float amount)
    {
        this.health -= amount;
        renderer.material.color = hitColor;
        this.hitTimer = 5f;

        if (this.moveTowards != null)
        {
            this.timer.Initilize();
            this.moveTowards.movement.Push(-transform.forward, PushPower.WEAK);
            this.moveTowards.enabled = false;
        }
    }

    private void Update()
    {
        if (this.hitTimer > 0)
        {
            this.hitTimer--;
            if (hitTimer <= 0)
            {
                this.renderer.material.color = Color.white;
            }
        }

        if (this.timer.IsFinished())
        {
            this.moveTowards.enabled = true;
        }
    }
}
