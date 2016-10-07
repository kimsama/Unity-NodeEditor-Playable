using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Director;

[RequireComponent(typeof(Animator))]
public class BlendAnimatorController : MonoBehaviour
{
    public AnimationClip clip;
    public RuntimeAnimatorController animController;
    private Animator animator;
    private AnimationMixerPlayable mixer;
    private AnimationClipPlayable clipPlayable;
    private AnimatorControllerPlayable controllerPlayable;
    void Awake()
    {
        animator = GetComponent<Animator>();
        animController = animator.runtimeAnimatorController;
    }

    void Start()
    {
        clip.wrapMode = WrapMode.Once;

        // Wrap the clip and the controller in playables
        clipPlayable = AnimationClipPlayable.Create(clip);
        controllerPlayable = AnimatorControllerPlayable.Create(animController);
        mixer = AnimationMixerPlayable.Create();
        mixer.SetInputs(new Playable[] { clipPlayable, controllerPlayable });

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            // Bind the playable graph to the player
            mixer.SetInputWeight(0, 1);
            mixer.SetInputWeight(1, 0);
            animator.Play(mixer);
        }

        if (Input.GetKey(KeyCode.U))
        {
            mixer.SetInputWeight(0, 0);
            mixer.SetInputWeight(1, 1);
            //animator.Play(mixer);

            // rewind otherwise the give clip is not played.
            clipPlayable.time = 0f;
        }

    }
}