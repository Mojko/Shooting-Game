using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float intensity;
    private bool shake;

    public void Shake(float intensity)
    {
        this.shake = true;
        this.intensity = intensity;
    }

    private void Update()
    {
        if (shake)
        {
            this.transform.position = new Vector3(this.transform.position.x + intensity * MathHelper.Choose(-1, 1), this.transform.position.y + intensity * MathHelper.Choose(-1,1), this.transform.position.z);
            intensity -= 0.1f;
            Debug.Log(intensity);
            if(intensity <= 0)
            {
                shake = false;
            }
        }
    }
}
