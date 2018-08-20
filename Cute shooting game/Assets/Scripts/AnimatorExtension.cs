using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorExtension
{
    public static bool IsPlaying(this Animator @this, Animation animation)
    {
       return @this.GetCurrentAnimatorStateInfo(0).IsName(animation.GetName());
    }

    public static bool AnimationHasEnded(this Animator @this, Animation animation)
    {
        return (@this.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1f && @this.IsPlaying(animation)) || !@this.IsPlaying(animation);
    }
}

public class Animation
{
    private string name;
    private AnimatorStateInfo stateInfo;

    public Animation(Animator animator, string name)
    {
        this.name = name;
        this.stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    public string GetName()
    {
        return this.name;
    }

    public AnimatorStateInfo GetStateInfo()
    {
        return this.stateInfo;
    }
}