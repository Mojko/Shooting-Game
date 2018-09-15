using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float damage;
    public Tag[] tagsRequired;

    private void OnTriggerEnter(Collider collider)
    {
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
}
