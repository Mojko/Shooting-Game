using System;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    public Gun gun;
    public Timer timer;

    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform[] spawnPositions;

    public new Animation animation;

    private float yStartRotation;
    private int nextBulletIndex;

    private void Start()
    {
        this.gun.Start();
        this.yStartRotation = this.transform.eulerAngles.y;
    }

    public bool Shoot(Animator animator)
    {
        if (this.timer.IsStarted() || this.IsOutOfAmmo())
        {
            return false;
        }

        this.timer.StartTimer();

        if (this.muzzleFlashPrefab != null)
        {
            this.muzzleFlashPrefab.GetComponent<MuzzleFlash>().Activate();
        }

        this.gun.ammo--;

        if (this.gun.shootOneBulletAtATime)
        {
            this.FireBullet(this.nextBulletIndex);
            this.nextBulletIndex++;
            if (this.nextBulletIndex >= this.spawnPositions.Length)
            {
                this.nextBulletIndex = 0;
            }
            return true;
        }

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            this.FireBullet(i);
        }

        return true;
    }

    public void Reload(Func<bool> action)
    {
        if(action())
        {
            this.gun.ammo = this.gun.originalAmmo;
        }
    }

    public bool IsOutOfAmmo()
    {
        return this.gun.ammo <= 0;
    }

    private void FireBullet(int index)
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, spawnPositions[index].position, Quaternion.identity);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        bullet.SetSlowOverTime(gun.slowOverTime);
        bullet.source = this;
        bulletInstance.transform.rotation = this.transform.rotation;
        //bulletInstance.transform.Rotate(this.transform.root.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y + gun.GetBulletDirection(index), 0);
        bulletInstance.GetComponent<DealDamage>().Ignore(this.transform.root.gameObject);
    }
}