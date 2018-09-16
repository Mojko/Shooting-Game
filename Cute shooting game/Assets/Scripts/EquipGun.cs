using UnityEngine;
using System.Collections;

public class EquipGun : MonoBehaviour
{
    public Transform hand;
    [Space(10)]
    [Header("This is the gun you'll start with. Then you can equip more")]
    public Gun gun;
    [HideInInspector] public Shooter shooter;

    private void Start()
    {
        this.Equip(this.gun);
    }

    public void Equip(Gun gun)
    {
        this.gun = gun;
        GameObject gunObject = Instantiate(this.gun.prefab);
        gunObject.transform.SetParent(hand);
        gunObject.transform.localPosition = gun.position;
        gunObject.transform.localEulerAngles = gun.rotation;
        gunObject.transform.localScale = gun.scale;
        this.shooter = gunObject.GetComponent<Shooter>();
    }
}