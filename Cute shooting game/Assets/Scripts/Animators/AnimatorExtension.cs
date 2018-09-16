using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorExtension
{
    public static void Play(this Animator @this, Animation animation)
    {
        @this.Play(animation.GetName());
    }

    public static bool IsPlaying(this Animator @this, Animation animation)
    {
        return @this.GetCurrentAnimatorStateInfo(0).IsName(animation.GetName());
    }

    public static bool AnimationHasEnded(this Animator @this, Animation animation)
    {
        return (@this.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.0f && @this.IsPlaying(animation)) || !@this.IsPlaying(animation);
    }
}

[System.Serializable]
public class Animation
{
    public Animator animator;
    public AnimationClip animationClip;

    public void Play()
    {
        animator.Play(this);
    }

    public bool HasEnded()
    {
        return animator.AnimationHasEnded(this);
    }

    public string GetName()
    {
        return this.animationClip.name;
    }

    public AnimatorStateInfo GetStateInfo()
    {
        return this.animator.GetCurrentAnimatorStateInfo(0);
    }
}