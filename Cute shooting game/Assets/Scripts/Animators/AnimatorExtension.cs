using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public static class AnimatorExtension
{
    public static void Play(this Animator @this, Animation animation)
    {
        @this.Play(animation.GetName());
    }

    public static bool IsPlaying(this Animator @this, Animation animation)
    {
        return @this.GetCurrentAnimatorStateInfo(animation.GetLayer()).IsName(animation.GetName()) && @this.GetCurrentAnimatorStateInfo(0).normalizedTime > 0;
    }

    public static bool AnimationHasEnded(this Animator @this, Animation animation)
    {
        return (@this.GetCurrentAnimatorStateInfo(animation.GetLayer()).normalizedTime > 1f && @this.GetCurrentAnimatorStateInfo(animation.GetLayer()).IsName(animation.GetName()));
    }

    public static void SetAnimatorController(this Animator @this, RuntimeAnimatorController controller)
    {
        @this.runtimeAnimatorController = controller;
    }

}

public class Animation
{
    public static Animation Shoot = new Animation("Shoot", 0);
    public static Animation Shoot_layer_2 = new Animation("Shoot", 2);
    public static Animation Reload = new Animation("Reload", 0);
    public static Animation Hit = new Animation("Hit", 0);
    public static Animation ShootFinalize = new Animation("Shoot_Finalize", 2);

    private string name;
    private int layer;

    public Animation(string name, int layer)
    {
        this.name = name;
        this.layer = layer;
    }

    public string GetName()
    {
        return this.name;
    }

    public int GetLayer()
    {
        return this.layer;
    }
}