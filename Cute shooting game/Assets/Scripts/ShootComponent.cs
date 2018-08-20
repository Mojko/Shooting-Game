using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] spawnPositions;
    public AnimatorController animatorController;
    public ShootAnimation shootAnimation;
    public float shootTimer;
    private float originalShootTimer;
    
    public float animationLifeTimeInSeconds;
    private float originalTime;

    private void Start()
    {
        this.originalShootTimer = shootTimer;
        this.originalTime = this.animationLifeTimeInSeconds;
    }
    
    private void Update()
    {
        if (this.shootTimer > 0)
        {
            shootTimer -= 1/60f;
        }
        
        /*if (this.animationLifeTimeInSeconds > 0)
        {
            this.animationLifeTimeInSeconds -= 1/60f;

            if (this.animationLifeTimeInSeconds <= 0)
            {
                this.animatorController.StopAim();
            }   
        }*/
    }
    
    public void Shoot()
    {
        if (this.shootTimer <= 0)
        {
            foreach (Transform transform in this.spawnPositions)
            {
                GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
                //bulletInstance.GetComponent<Bullet>().CreateBullet(this.transform.forward);   
            }
        
            this.shootAnimation.Shoot();

            this.animatorController.StartAim();
            this.animationLifeTimeInSeconds = this.originalTime;
            this.shootTimer = this.originalShootTimer;
        }
    }
}
