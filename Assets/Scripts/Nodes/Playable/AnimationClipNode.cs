using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

[Node(false, "Playable/AnimationClip Node")]
public class AnimationClipNode : Node 
{
    private const string Id = "animationClipNode";
    public override string GetID { get { return Id; } }
    public Type GetObjectType { get { return typeof(AnimationClipNode); } }

    public AnimationClip clip;

    public override Node Create(Vector2 pos)
    {
        AnimationClipNode node = CreateInstance<AnimationClipNode>();
        node.rect = new Rect(pos.x, pos.y, 200, 150);
        node.name = "AnimationClipNode";
        node.CreateOutput("Output1", "AnimationClip", NodeSide.Right);

        return node;
    }

    protected override void NodeGUI()
    {
        using (var hscope = new GUILayout.HorizontalScope())
        {
            clip = RTEditorGUI.ObjectField<AnimationClip>("Animation Clip", clip, true);
        }
    }

    public override bool Calculate()
    {
        Outputs[0].SetValue<AnimationClip>(clip);
        return true;
    }
}
