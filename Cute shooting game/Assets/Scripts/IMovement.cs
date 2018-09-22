using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Move(Vector3 direction);
    void Rotate(Vector3 direction);
    void Push(Vector3 direction, PushPower force, float? distance);
}
