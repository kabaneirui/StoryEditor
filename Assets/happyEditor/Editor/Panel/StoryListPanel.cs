#if UNITY_EDITOR

using UnityEngine;
namespace n.editor
{
    public class StoryListPanel : AbsPanel
    {
        public override void Init()
        {
            DefaultW = 300;
            MinW = 100;
        }
        protected override void Draw()
        {
            GUILayout.Button("剧情ID 100000", GUILayout.ExpandWidth(true));
            GUILayout.Button("剧情ID 100000", GUILayout.ExpandWidth(true));
            GUILayout.Button("剧情ID 100000", GUILayout.ExpandWidth(true));
            GUILayout.Button("剧情ID 100000", GUILayout.ExpandWidth(true));
            GUILayout.Button("剧情ID 100000", GUILayout.ExpandWidth(true));
            GUILayout.Button("剧情ID 100000", GUILayout.ExpandWidth(true));

        }
    }
}

#endif