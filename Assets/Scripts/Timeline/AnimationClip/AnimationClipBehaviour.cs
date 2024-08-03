using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public enum AnimationClipType
{
    Alive,
    Dash,
    Run,
    Attack
}

[Serializable]
public class AnimationClipBehaviour : PlayableBehaviour
{
    public AnimationClip clip;
    public AnimationClipType clipType;
    public bool autoToggle;
    public bool value;
    public float animationSpeed = 1;
    
    public override void OnPlayableCreate (Playable playable)
    {
        
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        var animator = info.output.GetUserData() as Animator;

        if (animator == null) return;

        if (clip == null)
        {
            animator.SetBool(clipType.ToString(), value);
        }
        else
        {
            animator.Play(clip.name);
        }
        
        animator.speed = animationSpeed;
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        var animator = info.output.GetUserData() as Animator;

        if (animator == null) return;

        if (clip == null)
        {
            if (autoToggle)
            {
                animator.SetBool(clipType.ToString(), !value);
            }
        }
    }
}
