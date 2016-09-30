using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework;

/// <summary>
/// 
/// </summary>
public abstract class AnimationPlayableBaseNode : Node
{

}

/// <summary>
/// 
/// </summary>
public class AnimationClipConnectionType : IConnectionTypeDeclaration
{
    public string Identifier { get { return "AnimationClip"; } }
    public Type Type { get { return typeof(AnimationClip); } }
    public Color Color { get { return Color.yellow; } }
    public string InKnobTex { get { return "Textures/In_Knob.png"; } }
    public string OutKnobTex { get { return "Textures/Out_Knob.png"; } }
}