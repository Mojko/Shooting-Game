using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public static class AnimatorValues
{
    public const string SpeedMultiplier = "speed";
    public const string AimTrigger = "Aim";
    public const string Shoot = "Shoot";
    public const string xSpeed = "xSpeed";
    public const string zSpeed = "zSpeed";
}

public enum AnimatorTypes
{
    Bool,
    Float
}