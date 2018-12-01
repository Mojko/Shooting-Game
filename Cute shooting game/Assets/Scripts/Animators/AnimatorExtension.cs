using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public static class AnimatorExtension
{
    //public static void Play(this Animator @this, UnityAnimation animation)
    //{
    //    @this.Play(animation.GetName());
    //}

    public static bool IsPlaying(this Animator @this, UnityAnimation animation, int layer = 0)
    {
        return @this.GetCurrentAnimatorStateInfo(layer).IsName(animation.name) && @this.GetCurrentAnimatorStateInfo(layer).normalizedTime > 0;
    }

    //public static bool AnimationHasEnded(this Animator @this, UnityAnimation animation)
    //{
    //    return (@this.GetCurrentAnimatorStateInfo(animation.GetLayer()).normalizedTime > 1f && @this.GetCurrentAnimatorStateInfo(animation.GetLayer()).IsName(animation.GetName()));
    //}

    public static void SetAnimatorController(this Animator @this, RuntimeAnimatorController controller)
    {
        @this.runtimeAnimatorController = controller;
    }

    public static void SetFloat(this Animator @this, UnityAnimationParameter parameter, float value)
    {
        @this.SetFloat(parameter.name, value);
    }

    public static void SetTrigger(this Animator @this, UnityAnimationParameter parameter)
    {
        @this.SetTrigger(parameter.name);
    }

    public static void SetBool(this Animator @this, UnityAnimationParameter parameter, bool value)
    {
        @this.SetBool(parameter.name, value);
    }
}

public class UnityLayer
{
    public readonly int layer;
    public readonly UnityAnimation[] animations;

    public UnityLayer(int layer, params UnityAnimation[] animations)
    {
        this.layer = layer;
        this.animations = animations;
    }
}

public class UnityAnimation
{

    public static UnityAnimation shoot = new UnityAnimation("Shoot");
    public static UnityAnimation reload = new UnityAnimation("Reload");
    public static UnityAnimation hit = new UnityAnimation("Hit");
    public static UnityAnimation shootFinalize = new UnityAnimation("ShootFinalize");


    public readonly string name;

    public UnityAnimation(string name)
    {
        this.name = name;
    }
}

//public class UnityAnimation
//{
//    public static UnityAnimationLayer Layer_0 = new UnityAnimationLayer(0,
//        Shoot
//    );

//    private static UnityAnimation Shoot = new UnityAnimation("Shoot");

//    //public static UnityAnimation Shoot = new UnityAnimation("Shoot", 0);
//    //public static UnityAnimation Shoot_layer_2 = new UnityAnimation("Shoot", 2);
//    //public static UnityAnimation Reload = new UnityAnimation("Reload", 0);
//    //public static UnityAnimation Hit = new UnityAnimation("Hit", 0);
//    //public static UnityAnimation ShootFinalize = new UnityAnimation("Shoot_Finalize", 2);

//    private string name;
//    private int layer;
//    private UnityAnimationParameter[] parameters;

//    public UnityAnimation(string name, params UnityAnimationParameter[] parameters)
//    {
//        this.name = name;
//        this.parameters = parameters;
//    }

//    public string GetName()
//    {
//        return this.name;
//    }

//    public void SetLayer(int layer)
//    {
//        this.layer = layer;
//    }

//    public int GetLayer()
//    {
//        return this.layer;
//    }
//}

//public class UnityAnimationLayer
//{
//    public readonly int layer;

//    public UnityAnimationLayer(int layer, params UnityAnimation[] animations)
//    {
//        this.layer = layer;

//        foreach(var animation in animations)
//        {
//            animation.SetLayer(layer);
//        }
//    }
//}

public class UnityAnimationParameter
{
    public static UnityAnimationParameter xSpeed = new UnityAnimationParameter("xSpeed", UnityAnimationParameterType.Float);
    public static UnityAnimationParameter zSpeed = new UnityAnimationParameter("zSpeed", UnityAnimationParameterType.Float);
    public static UnityAnimationParameter Shoot = new UnityAnimationParameter("Shoot", UnityAnimationParameterType.Bool);
    public static UnityAnimationParameter FreeMoving = new UnityAnimationParameter("FreeMoving", UnityAnimationParameterType.Bool);
    public static UnityAnimationParameter OneHanded = new UnityAnimationParameter("OneHanded", UnityAnimationParameterType.Trigger);
    public static UnityAnimationParameter TwoHanded = new UnityAnimationParameter("TwoHanded", UnityAnimationParameterType.Trigger);
    public static UnityAnimationParameter Hit = new UnityAnimationParameter("Hit", UnityAnimationParameterType.Trigger);
    public static UnityAnimationParameter ShootFinalize = new UnityAnimationParameter("ShootFinalize", UnityAnimationParameterType.Trigger);

    public readonly UnityAnimationParameterType parameter;
    public readonly string name;

    public UnityAnimationParameter(string name, UnityAnimationParameterType parameter)
    {
        this.name = name;
        this.parameter = parameter;
    }
}

public enum UnityAnimationParameterType
{
    Float,
    Trigger,
    Bool
}