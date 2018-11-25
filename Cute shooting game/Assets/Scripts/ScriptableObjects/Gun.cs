using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public GameObject prefab;
    [Range(0, 360)] public float[] bulletDirections;
    [Range(0, 4)] public float power;
    public ShootType shootType;
    public bool isOneHanded;
    public int ammo;
    public int originalAmmo;

    [Header("In hand")]
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    [Header("Bullet")]
    public bool slowOverTime;
    public bool shootOneBulletAtATime;

    public void Start()
    {
        this.ammo = this.originalAmmo;
    }

    public float GetBulletDirection(int bulletIndex)
    {
        return this.bulletDirections[bulletIndex];
    }

    private bool Match(Shooter shooter)
    {
        return shooter.spawnPositions.Length == bulletDirections.Length;
    }
}

public enum ShootType
{
    Click,
    Hold
}