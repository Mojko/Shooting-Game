using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour 
{
    public void Activate()
    {
        this.gameObject.SetActive(true);
        Invoke("Deactivate", 0.1f);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}