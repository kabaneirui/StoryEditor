#if UNITY_EDITOR
using System;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public class StoryInspectPanel : AbsPanel
    {
        public static Editor NodeEditor;

        public override void Init()
        {
            DefaultW = 400;
            MinW = 100;
        }
        protected override void Draw()
        {
            if (NodeEditor)
                NodeEditor.OnInspectorGUI();
        }

    }
}

#endif