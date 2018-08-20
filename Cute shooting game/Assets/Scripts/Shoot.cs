using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Animator animator;
	public Transform[] spawnPositions;
	public Timer shootTimer;
	public GameObject muzzleFlashPrefab;

	private void Start()
	{
		
	}
	
	public void Initilize()
	{
		if (shootTimer.HasEnded())
		{
			shootTimer.Initilize();
			animator.Play("Shoot");
			this.muzzleFlashPrefab.GetComponent<MuzzleFlash>().Activate();
			
			for (int i = 0; i < spawnPositions.Length; i++)
			{
				GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

				int value = ((i & 1) == 1) ? -1 : 1;
				
				Vector3 direction = this.transform.root.forward - this.transform.root.right/(24 * value);
				
				bulletInstance.GetComponent<Bullet>().CreateBullet(direction);
			}
		}
	}
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
