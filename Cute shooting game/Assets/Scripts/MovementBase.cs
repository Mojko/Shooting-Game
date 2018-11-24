using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase : MonoBehaviour, IMovement
{
    public virtual void Move(Vector3 direction)
    {

    }

    public virtual void Rotate(Vector3 direction, float smooth)
    {
        Vector3 rotation = new Vector3(direction.x, 0, direction.z);

        if (rotation != Vector3.zero)
        {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotation), smooth);
        }
    }

    public void RotateTowards(Transform transform)
    {
        this.transform.LookAt(new Vector3(transform.position.x, this.transform.position.y, transform.position.z));
    }

    public virtual void Push(Vector3 direction, PushPower force, float? distance)
    {
        Vector3 forceDirection = new Vector3(direction.x, 0, direction.z);

        if (distance != null)
        {
            float newDistance = Mathf.Clamp((float) distance, 0, 10);
            float remappedDistance = MathHelper.RemapValue(newDistance, 0, 10, 2, 0);
            //Debug.Log("New distance: " + newDistance + ", remappedDistance: " + remappedDistance + ", Real Distance: " + ((float) distance));
            forceDirection *= remappedDistance / 3;
        }

        this.transform.position += forceDirection;
    }

    public void LookAt(Transform target)
    {
        this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
    }
}
