using UnityEngine;
using System.Collections;

public class StandardEnemyAnimatorController : MonoBehaviour 
{
    public Animator animator;
    public AIMovement movement;

    private float xSpeed;
    private float zSpeed;

    private void Update()
    {
        this.xSpeed = Mathf.Lerp(this.xSpeed, this.movement.navMeshAgent.velocity.x, 0.4f);
        this.zSpeed = Mathf.Lerp(this.zSpeed, this.movement.navMeshAgent.velocity.z, 0.4f);

        this.animator.SetFloat(AnimatorValues.xSpeed, Mathf.Round(this.xSpeed * 10) / 10);
        this.animator.SetFloat(AnimatorValues.zSpeed, Mathf.Round(this.zSpeed * 10) / 10);
    }
}