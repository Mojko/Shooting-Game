using UnityEngine;
using System.Collections;

public class DestroyOnFinish : MonoBehaviour 
{
    private ParticleSystem system;

    private void Start()
    {
        this.system = this.GetComponent<ParticleSystem>();
    }

	private void Update ()
	{
        if (!this.system.IsAlive())
        {
            Destroy(this.gameObject);
        }
	}
}