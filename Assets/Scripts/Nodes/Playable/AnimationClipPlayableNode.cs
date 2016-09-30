using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "Playable/AnimationClipPlayable Node")]
public class AnimationClipPlayableNode : AnimationPlayableBaseNode 
{

    private const string Id = "animationClipPlayableNode";
    public override string GetID { get {return Id;} }
    public Type GetObjectType { get { return typeof(AnimationClipPlayableNode); } }


    public override Node Create(Vector2 pos)
    {
        AnimationClipPlayableNode node = CreateInstance<AnimationClipPlayableNode>();
        node.rect = new Rect(pos.x, pos.y, 200, 150);
        node.name = "AnimationClipPlayable";
        node.CreateInput("Input1", "AnimationClip");

        return node;
    }

    protected override void NodeGUI()
    {
    }
}
