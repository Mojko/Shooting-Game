using UnityEngine;
using System.Collections;

public class RayCastHelper 
{
    public static bool ShootRay(Vector3 from, Vector3 to, out RaycastHit hit)
    {
        Ray originalRay = GetRayBetweenPoints(to);

        Ray ray = new Ray(from, -originalRay.direction);

        return Physics.Raycast(ray, out hit, Mathf.Infinity);
    }

    public static Ray GetRayBetweenPoints(Vector3 to)
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(to);

        Ray ray = Camera.main.ScreenPointToRay(screenPoint);

        return ray;
    }

    public static void DrawRay(Vector3 from, Vector3 to)
    {
        Ray ray = GetRayBetweenPoints(to);
        Debug.DrawRay(from, -ray.direction * Vector3.Distance(from, to), Color.red);
    }
}