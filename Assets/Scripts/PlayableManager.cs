using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using NodeEditorFramework;

/// <summary>
/// 
/// </summary>
public class PlayableManager : MonoBehaviour 
{
    AnimationPlayableInstance playableInst;
    
	void Start () 
    {
        Animator animator = GetComponent<Animator>();

        // Load NodeCanvas asset
        var path = "Assets/Plugins/Node_Editor/Resources/Saves/PlayableCanvas.asset";
        var canvas = NodeEditorSaveManager.LoadNodeCanvas(path, false);
        
        // Set input/output values on runtime, otherwise all input/output have null
        foreach (Node n in canvas.nodes)
            n.Calculate();

        // Find AnimationPlayableMixerNode
        AnimationPlayableBaseNode node = FindNode(canvas);

		playableInst = new AnimationPlayableInstance(animator, node);

        // Mixing animations.
        playableInst.Execute();
	}

    AnimationPlayableBaseNode FindNode(NodeCanvas canvas)
    {
        var result = canvas.nodes.Where(n => n.GetType() == typeof(AnimationMixerPlayableNode)).FirstOrDefault();
        return (AnimationPlayableBaseNode)result;
    }
	
}
