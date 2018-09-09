using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public MoveTowards moveTowards;
    public float health;
    public Color hitColor;
    public Renderer[] renderers;
    public Timer timer;
    public PushPower pushPower;

    public void Hurt(float amount)
    {
        this.health -= amount;
        this.SetColor(this.hitColor);
        if (this.moveTowards != null)
        {
            this.timer.Initilize(this.OnFinish);
            this.moveTowards.movement.Push(-transform.forward, this.pushPower);
            this.moveTowards.enabled = false;
        }
    }

    private void OnFinish()
    {
        this.moveTowards.enabled = true;
        this.SetColor(Color.white);
    }

    public void SetColor(Color color)
    {
        foreach (Renderer renderer in this.renderers)
        {
            renderer.material.color = color;
        }
    }
}
