using UnityEngine;

public static class MathHelper 
{
    public static float Choose(params float[] values)
    {
        int index = Random.Range(0, values.Length);
        return values[index];
    }

    public static float Reverse(float value, float min, float max)
    {
        return (value / max);
    }

    public static float RemapValue(float value, float low1, float high1, float low2, float high2)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }

    public static Vector3 GetAngle(Vector3 pos1, Vector3 pos2)
    {
        return pos1 - pos2;
    }

    public static float GetSide(Transform me, Transform target)
    {
        Vector3 perp = Vector3.Cross(me.forward, target.forward);
        float direction = Vector3.Dot(perp, me.transform.up);

        if (direction > 0f)
        {
            return 1f;
        }
        else if (direction < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }
}
