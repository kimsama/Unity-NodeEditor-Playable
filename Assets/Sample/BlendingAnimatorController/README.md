# Blending the AnimatorController

A simple demo which shows a way to blend an animation of the given animation clip' with the exist AnimatorController's one.

Let's consider the case of making an action game something like *Monster Hunters* or *DarkSoul*. 

Generally a player character of those kind of an action game has various attack animations depends on the type of the weapon on a player's hand.

Using Mecanim's  StateMachine to set locomotion of a character is easy and the right way to get a character's movement.
But setting all attack animations on the Mecanim's StateMachine is redundant and tedious job. Even worse things are that the necessary attack animations can be continously changed whenever a player changes his or her weapon.

Now there is a new way to get the job done which are called [Playable APIs](https://docs.unity3d.com/Manual/Playables.html) provided by newly version of Unity(from 5.3.x but still experimental and on going changes).

The demo was writtern with Unity 5.5.0b2.


The following code shows how to create animation blend tree through code. It creates two animation blend tree, one is from animation clip and the other is from AnimatorController.

```
    // an attack animation clip
    public AnimationClip clip;

    private Animator animator;
    private RuntimeAnimatorController animController;
    private AnimationMixerPlayable mixer;
    private AnimationClipPlayable clipPlayable;
    private AnimatorControllerPlayable controllerPlayable;

    void Awake()
    {
        // Setup RuntimeAnimatorController from Animator.
        animator = GetComponent<Animator>();
        animController = animator.runtimeAnimatorController;
    }

    void Start()
    {
        clip.wrapMode = WrapMode.Once;

        // Wrap the clip and the controller in playables
        clipPlayable = AnimationClipPlayable.Create(clip);
        controllerPlayable = AnimatorControllerPlayable.Create(animController);

        // Create mixer
        mixer = AnimationMixerPlayable.Create();

        // each of input has its index order by it is set.
        mixer.SetInputs(new Playable[] { clipPlayable, controllerPlayable });
    }
```

With changing the weight of each clip in the blend, it can blend and change animations from one to the other over time.

Pressing *'J'* plays attack animation and *'U'* set 0 for the weight value of attack animation clip so the player character start to play 'idle' animation again.

```
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            // Set weight before mixing.
            mixer.SetInputWeight(0, 1); // attack clip as 0
            mixer.SetInputWeight(1, 0); // runtime animator controller as 1

            // Now it plays attack animation
            animator.Play(mixer);

            // it pauses AnimatorController
        }

        if (Input.GetKey(KeyCode.U))
        {
            // After setting weight value of the attack to 0, AnimatorController works again.
            mixer.SetInputWeight(0, 0);
            mixer.SetInputWeight(1, 1);
            //animator.Play(mixer);

            // Rewind otherwise the give clip is not played.
            clipPlayable.time = 0f;
        }
    }
```

Note that before starting play the attack animation again, it should reset `clipPlayable.time` to 0 to make it play from its start time when it starts to play attack animation again.

