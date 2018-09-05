using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour
{
    public float time;

    public void Activate()
    {
        this.gameObject.SetActive(true);
        Invoke("Deactivate", time);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}