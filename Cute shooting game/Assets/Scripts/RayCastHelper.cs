using UnityEngine;
using System.Collections;

public class RayCastHelper 
{
    public static bool ShootRay(Vector3 from, Vector3 direction, float distance, out RaycastHit hit)
    {
        Ray ray = new Ray(from, direction);

        if(Physics.Raycast(ray, out hit, distance))
        {
            return true;
        }

        return false;
    }

    public static Ray GetRayBetweenPoints(Vector3 to)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(to);

        Ray ray = Camera.main.ScreenPointToRay(screenPoint);

        return ray;
    }

    /// <summary>
    /// Shoots line between two points and returns the point it hits
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static bool ShootLine(Vector3 from, Vector3 to, out Vector3 point)
    {
        RaycastHit hit;
        if (Physics.Linecast(from, to, out hit))
        {
            point = hit.point;
            return true;
        }

        point = Vector3.zero;
        return false;
    }

    public static bool ShootLine(Vector3 from, Vector3 to, GameObject expectedHit, out Vector3 point)
    {
        RaycastHit hit;
        if (Physics.Linecast(from, to, out hit))
        {
            if(hit.collider.gameObject == expectedHit)
            {
                point = hit.point;
                return true;
            }
        }

        point = Vector3.zero;
        return false;
    }

    public static void DrawRay(Vector3 from, Vector3 to)
    {
        Ray ray = GetRayBetweenPoints(to);
        Debug.DrawRay(from, -ray.direction * Vector3.Distance(from, to), Color.red);
    }
}