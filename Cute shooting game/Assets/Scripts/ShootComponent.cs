using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] spawnPositions;
    public AnimatorController animatorController;
    
    public float animationLifeTimeInSeconds;
    private float originalTime;
    
    private void Update()
    {
        if (this.animationLifeTimeInSeconds > 0)
        {
            this.animationLifeTimeInSeconds -= 1/60f;

            if (this.animationLifeTimeInSeconds <= 0)
            {
                this.animatorController.StopAim();
            }   
        }
    }
    
    public void Shoot()
    {
        foreach (Transform transform in this.spawnPositions)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
            bulletInstance.GetComponent<Bullet>().CreateBullet(this.transform.forward);   
        }

        this.animationLifeTimeInSeconds = 1;
    }
}
