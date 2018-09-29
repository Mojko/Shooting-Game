using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using System.Threading;

public class Shooter : MonoBehaviour
{
    public Gun gun;

    public Animator animator;
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform[] spawnPositions;

    public new Animation animation;

    private float yStartRotation;

    private void Start()
    {
        this.yStartRotation = this.transform.eulerAngles.y;
    }

    public bool Shoot()
    {
        if (!this.animator.AnimationHasEnded(Animation.Shoot) && this.gun.shootType == ShootType.Hold)
        {
            return false;
        }

        this.animator.Play(Animation.Shoot);
        this.muzzleFlashPrefab.GetComponent<MuzzleFlash>().Activate();

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, spawnPositions[i].position, Quaternion.identity);
            Bullet bullet = bulletInstance.GetComponent<Bullet>();
            bullet.SetSlowOverTime(gun.slowOverTime);
            bullet.source = this;
            bulletInstance.transform.Rotate(0, this.transform.rotation.eulerAngles.y + gun.GetBulletDirection(i), 0);
            //bulletInstance.transform.Rotate(0, this.transform.rotation.eulerAngles.y + gun.GetBulletDirection(i), 0);
            bulletInstance.GetComponent<DealDamage>().Ignore(this.transform.root.gameObject);
        }

        return true;
    }
}