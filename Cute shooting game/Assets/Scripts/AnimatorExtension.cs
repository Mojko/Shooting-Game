using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorExtension
{
    public static void Play(this Animator @this, Animation animation)
    {
        Debug.Log("Now playing animation: " + animation.GetName());
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
    public Animations animation;
    public Animator animator;
    public AnimationClip animationClip;

    public void Play()
    {
        this.animator.Play(this);
    }

    public bool HasEnded()
    {
        return this.animator.AnimationHasEnded(this);
    }

    public string GetName()
    {
        switch (animation)
        {
            case Animations.Shoot:
                return "Shoot";
        }

        return "";
    }

    public AnimatorStateInfo GetStateInfo()
    {
        return this.animator.GetCurrentAnimatorStateInfo(0);
    }
}

public enum Animations
{
    Shoot
}