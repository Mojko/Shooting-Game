using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour 
{
    public AIBehaviour behaviour;
    public Animator animator;

	private void Start ()
	{
		
	}
	
	private void Update ()
	{
	}

    public void OnChangeDestination()
    {

    }

    public void Move()
    {
        if(this.animator.GetFloat("zSpeed") != 1f)
        {
            this.animator.SetFloat("zSpeed", 1f);
        }
    }

    public void Stop()
    {
        if (this.animator.GetFloat("zSpeed") != 0f)
        {
            this.animator.SetFloat("zSpeed", 0f);
        }
    }
}