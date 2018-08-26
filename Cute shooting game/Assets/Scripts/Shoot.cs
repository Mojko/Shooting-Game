using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    /* public GameObject bulletPrefab;
    public Animator animator;
    public Transform[] spawnPositions;
    public Timer shootTimer;
    public GameObject muzzleFlashPrefab;

    private Animation animation;
    private GameObject entity;

    private void Start()
    {
        this.animation = new Animation(animator, "Shoot");
        this.entity = this.transform.root.gameObject;
    }

    public void Initilize()
    {
        if (animator.AnimationHasEnded(animation))
        {
            shootTimer.Initilize();
            animator.Play("Shoot");
            this.muzzleFlashPrefab.GetComponent<MuzzleFlash>().Activate();
			
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                GameObject bulletInstance = Instantiate(bulletPrefab, spawnPositions[i].position, Quaternion.identity);

                bulletInstance.GetComponent<Bullet>().CreateBullet(this.entity.transform, 0);
            }
        }
    }*/
}

/*
 *
 *         float xPos = Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad);
        float yPos = Mathf.Sin(-transform.eulerAngles.x * Mathf.Deg2Rad);
        float zPos = Mathf.Cos(transform.eulerAngles.x * Mathf.Deg2Rad) * Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad);
 
        print(xPos + ", " + yPos + ", " + zPos + ", " + transform.forward);
 */




//
//			this.shootAnimation.Shoot();
//
//			this.animatorController.StartAim();
//			this.animationLifeTimeInSeconds = this.originalTime;
//			this.shootTimer = this.originalShootTimer;

//float xDir = Mathf.Sin(this.transform.root.rotation.eulerAngles.y * Mathf.Deg2Rad) * Mathf.Cos(this.transform.root.rotation.eulerAngles.x * Mathf.Deg2Rad);
//float yDir = Mathf.Sin(-this.transform.root.eulerAngles.x * Mathf.Deg2Rad);
//float zDir = Mathf.Cos((this.transform.root.rotation.eulerAngles.x) * Mathf.Deg2Rad) * Mathf.Cos((this.transform.root.rotation.eulerAngles.y) * Mathf.Deg2Rad);
