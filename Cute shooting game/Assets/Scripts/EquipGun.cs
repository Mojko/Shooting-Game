using UnityEngine;
using System.Collections;

public class EquipGun : MonoBehaviour
{
    public Transform hand;
    [Space(10)]
    [Header("This is the gun you'll start with. Then you can equip more")]
    public Gun gun;

    private void Start()
    {
        this.Equip(this.gun);
    }

    public void Equip(Gun gun)
    {
        this.gun = gun;
        GameObject gunObject = this.gun.Instantiate();//Instantiate(this.gun.shooter.gameObject);
        gunObject.transform.SetParent(hand);

        //this.gunObject = Instantiate(this.gun.prefab);
        //this.gunObject.transform.SetParent(hand);
    }
}