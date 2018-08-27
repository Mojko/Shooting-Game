using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricVector3 {

    public static IsometricVector3 forward = new IsometricVector3(0, 1);

    private Vector3 actualVector;
    public float x;
    public float z;

    public IsometricVector3(float x, float z)
    {
        this.actualVector = new Vector3(x, 0, z);
        this.x = x;
        this.z = z;
    }
}
