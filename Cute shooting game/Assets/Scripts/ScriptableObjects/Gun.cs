using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun : ScriptableObject
{
    public GameObject prefab;
    private Shoot sceneObject;

    public void Shoot()
    {
        this.sceneObject.Initilize();
    }

    public Shoot CreateGun()
    {
        GameObject gunObject = Instantiate(this.prefab);
        this.sceneObject = gunObject.GetComponent<Shoot>();
        return this.sceneObject;
    }
}