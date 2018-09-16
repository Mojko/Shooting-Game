using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour
{
    public Movement movement;

    private void Update()
    {
        Plane groundPlane = new Plane(Vector3.up, -transform.position.y);
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDistance;

        if (groundPlane.Raycast(mouseRay, out hitDistance))
        {
            var lookAtPosition = mouseRay.GetPoint(hitDistance);
            var dir = lookAtPosition - this.transform.position;
            var rot = Quaternion.LookRotation(lookAtPosition, Vector3.up);
            this.movement.Rotate(dir);
        }
    }
}