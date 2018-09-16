using UnityEngine;
using System.Collections;

public class AIShootController : MonoBehaviour 
{
    public EquipGun gunController;
    public Timer shootTimer;

	private void Update ()
	{
	    if(Random.Range(1,100) == 1 && !this.shootTimer.IsStarted())
        {
            this.shootTimer.Initilize(this.Shoot);
        }	
	}

    private void Shoot()
    {
        this.gunController.shooter.Shoot();
    }
}