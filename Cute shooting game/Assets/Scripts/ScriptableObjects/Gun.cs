using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public Shooter shooter;
    private Shooter shooterInstance;
    [Range(0, 360)] public float[] bulletDirections;
    [Range(0, 4)] public float power;

    [Header("In hand")]
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    [Header("Bullet")]
    public bool slowOverTime;

    public void Shoot()
    {
        this.shooterInstance.Shoot();
    }

    public float GetBulletDirection(int bulletIndex)
    {
        return this.bulletDirections[bulletIndex];
    }

    public GameObject Instantiate()
    {
        GameObject shooterObject = Instantiate(this.shooter.gameObject);
        this.shooterInstance = shooterObject.GetComponent<Shooter>();
        Debug.Log("Created object: " + scale);
        return shooterObject;
    }

    private bool Match(Shooter shooter)
    {
        return shooter.spawnPositions.Length == bulletDirections.Length;
    }
}