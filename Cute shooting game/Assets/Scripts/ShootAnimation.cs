using UnityEngine;
using System.Collections;

public class ShootAnimation : MonoBehaviour
{
	private Animator animator;
	private void Start()
	{
		this.animator = this.GetComponent<Animator>();
	}
	
	public void Shoot()
	{
		animator.Play("Shoot");
		//animator.SetTrigger(AnimatorValues.Shoot);
	}
}