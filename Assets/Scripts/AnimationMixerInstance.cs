using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Director;
using NodeEditorFramework;

/// <summary>
/// 
/// </summary>
public class AnimationPlayableInstance 
{
    Animator animator;
    AnimationMixerPlayable mixer;


    public AnimationPlayableInstance(Animator _animator, AnimationPlayableBaseNode node)
    {
        animator = _animator;

        mixer = AnimationMixerPlayable.Create();

        AnimationClip c = node.Inputs[0].GetValue<AnimationClip>();
        AnimationClip[] sources = node.Inputs.Select(x=>x.GetValue<AnimationClip>()).ToArray();
        mixer.SetInputs(sources);
    }

    public void Execute()
    {
        animator.Play(mixer);
    }
}
