using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public Shooter shooter;
    private Shooter shooterInstance;
    [Range(0, 360)] public float[] bulletDirections;
    [Range(0, 4)] public float power;
    public bool bulletSlowOverTime;

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
        return shooterObject;
    }

    private bool Match(Shooter shooter)
    {
        return shooter.spawnPositions.Length == bulletDirections.Length;
    }
}