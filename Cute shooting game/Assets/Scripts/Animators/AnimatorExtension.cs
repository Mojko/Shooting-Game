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
        return @this.GetCurrentAnimatorStateInfo(0).IsName(animation.GetName()) && @this.GetCurrentAnimatorStateInfo(0).normalizedTime > 0;
    }

    public static bool AnimationHasEnded(this Animator @this, Animation animation)
    {
        return (@this.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0f && @this.IsPlaying(animation));
    }

    public static void SetAnimatorController(this Animator @this, RuntimeAnimatorController controller)
    {
        @this.runtimeAnimatorController = controller;
    }

}

public class Animation
{
    public static Animation Shoot = new Animation("Shoot");
    public static Animation Reload = new Animation("Reload");

    private string name;

    public Animation(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return this.name;
    }
}