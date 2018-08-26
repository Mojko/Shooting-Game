using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public GameObject prefab;
    public GameObject bulletPrefab;
    public GameObject muzzleFlashPrefab;
    public ShootType shootType;
    public Animation animation;
    public Transform[] spawnPositions;

    private Animator animator;
    private GameObject instance;
    private float directionOffset;
    private Shooter shooter;

    private void Start()
    {
        switch (this.shootType)
        {
            case ShootType.Shotgun:
                this.directionOffset = 0;
                break;
        }
    }

    public GameObject Instantiate()
    {
        this.instance = Instantiate(this.prefab);
        this.shooter = this.instance.GetComponent<Shooter>();

        return this.instance;
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
                bulletInstance.transform.Rotate(0, this.transform.eulerAngles.y + directionOffset, 0);
            }
        }
    }

    public GameObject GetInstance()
    {
        return this.instance;
    }
}

public enum ShootType
{
    Shotgun
}