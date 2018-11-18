using UnityEngine;
using System.Collections;

public class DestroyOnFinish : MonoBehaviour 
{
    public ParticleSystem system;

	private void Update ()
	{
        if (!this.system.IsAlive())
        {
            Destroy(this.gameObject);
        }
	}
}