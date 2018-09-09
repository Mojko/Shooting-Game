using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using System.Threading;

public class Shooter : MonoBehaviour
{
    public Gun gun;

    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform[] spawnPositions;

    public new Animation animation;

    private ScreenShake screenShake;
    private float yStartRotation;

    private void Start()
    {
        this.screenShake = Camera.main.GetComponent<ScreenShake>();
        this.yStartRotation = this.transform.eulerAngles.y;
    }

    public void Shoot()
    {
        if (this.animation.HasEnded())
        {
            this.animation.Play();
            this.muzzleFlashPrefab.GetComponent<MuzzleFlash>().Activate();

            for (int i = 0; i < spawnPositions.Length; i++)
            {
                GameObject bulletInstance = Instantiate(bulletPrefab, spawnPositions[i].position, Quaternion.identity);
                bulletInstance.GetComponent<Bullet>().SetSlowOverTime(gun.slowOverTime);
                bulletInstance.transform.Rotate(0, (this.transform.eulerAngles.y + this.yStartRotation) + gun.GetBulletDirection(i), 0);
            }

            screenShake.Shake(gun.power);
        }
    }
}