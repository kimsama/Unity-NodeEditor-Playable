using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Director;
using NodeEditorFramework;

/// <summary>
/// Runtime instance for a AnimationMixerPlayableNode
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

    /// <summary>
    /// Mixing input animation clips.
    /// </summary>
    public void Execute()
    {
        animator.Play(mixer);
    }

    /// <summary>
    /// Change weight value of the given input animation clip's
    /// </summary>
    public void SetWeight(float w)
    {
        mixer.SetInputWeight(0, 1 - w); // 0: idle
        mixer.SetInputWeight(1, w);     // 1: walk
    }
}
