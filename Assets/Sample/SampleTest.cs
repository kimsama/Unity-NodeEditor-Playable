using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Director;

public class SampleTest : MonoBehaviour {

    Animator animator;
    AnimationMixerPlayable mixer;
    public AnimationClip idle;
    public AnimationClip walk;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        mixer = AnimationMixerPlayable.Create();
        mixer.SetInputs( new[] { idle, walk });
        animator.Play(mixer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
