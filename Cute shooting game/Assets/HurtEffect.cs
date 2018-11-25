using UnityEngine;
using System.Collections;

public class HurtEffect : MonoBehaviour 
{
    public ParticleSystem effect;
    public Vector3 offset;

	private void OnEnable ()
	{
        Vector3 position = this.transform.position + offset;

        Instantiate(this.effect, position, Quaternion.identity);

        this.Disable();
	}
}