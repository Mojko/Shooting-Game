using System;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float damage;
    public Tag[] tagsRequired;
    private GameObject ignore;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider == null || collider.gameObject == this.ignore || collider.CompareTag(this.ignore.tag))
        {
            return;
        }

        foreach(Tag tag in this.tagsRequired)
        {
            if (collider.CompareTag(TagParser.Parse(tag)))
            {
                HealthManager target = collider.gameObject.GetComponent<HealthManager>();
                if (target != null)
                {
                    target.Hurt(this, this.damage);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    public bool IsProjectile()
    {
        return this.CompareTag(TagParser.Parse(Tag.Projectile));
    }

    public void Ignore(GameObject gameObjectToIgnore)
    {
        this.ignore = gameObjectToIgnore;
    }
}
