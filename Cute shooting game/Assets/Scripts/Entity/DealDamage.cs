using System;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float damage;
    public Tag[] tagsRequired;
    private GameObject ignore;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject == this.ignore || collider.CompareTag(this.ignore.tag))
        {
            return;
        }

        foreach(Tag tag in this.tagsRequired)
        {
            if (collider.CompareTag(TagParser.Parse(tag)))
            {
                TakeDamage target = collider.gameObject.GetComponent<TakeDamage>();
                if (target != null)
                {
                    target.Hurt(this, this.damage);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    internal void Ignore(GameObject gameObjectToIgnore)
    {
        this.ignore = gameObjectToIgnore;
    }
}
