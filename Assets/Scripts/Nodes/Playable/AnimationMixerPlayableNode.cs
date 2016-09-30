using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;

/// <summary>
/// 
/// </summary>
[Node(false, "Playable/AnimationMixerPlayableNode")]
public class AnimationMixerPlayableNode : AnimationPlayableBaseNode
{
    private const string Id = "animationMixerPlayableNode";
    public override string GetID { get { return Id; } }

    public float weight;

    public override Node Create(Vector2 pos)
    {
        AnimationMixerPlayableNode node = CreateInstance<AnimationMixerPlayableNode>();
        node.rect = new Rect(pos.x, pos.y, 200, 150);
        node.name = "AnimationMixerPlayableNode";
        node.CreateInput("Input1", "AnimationClip", NodeSide.Left, 30);
        node.CreateInput("Input2", "AnimationClip", NodeSide.Left, 60);

        return node;
    }
    protected override void NodeGUI()
    {
        
    }

    public override bool Calculate()
    {
        if (Inputs[0].connection == null || Inputs[1].connection == null ||
            Inputs[0].connection.IsValueNull || Inputs[1].connection.IsValueNull)
            return false;

        return true;
    }
}
