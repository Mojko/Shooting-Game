using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public Gun gun;

    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform[] spawnPositions;

    public new Animation animation;

    private ScreenShake screenShake;
    private float yStartRotation;

    private AnimatorOverrideController overrideController;

    private void Start()
    {
        this.screenShake = Camera.main.GetComponent<ScreenShake>();
        this.yStartRotation = this.transform.eulerAngles.y;

        //this.overrideController = new AnimatorOverrideController(this.animation.animator.runtimeAnimatorController);

        //if (this.overrideController != null)
        //{
        //    this.overrideController["Shoot"] = this.animation.animationClip;
        //    this.animation.animator.runtimeAnimatorController = overrideController;
        //}

        //overrideController["Shoot"] = this.animation.animationClip;

        //this.animation.animator.runtimeAnimatorController.animationClips[0] = this.animation.animationClip;
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
                bulletInstance.transform.Rotate(0, (this.transform.eulerAngles.y) + gun.GetBulletDirection(i), 0);
                if (gun.bulletSlowOverTime)
                {
                    bulletInstance.GetComponent<Bullet>().SlowOverTime();
                }
            }

            screenShake.Shake(gun.power);
        }
    }
}