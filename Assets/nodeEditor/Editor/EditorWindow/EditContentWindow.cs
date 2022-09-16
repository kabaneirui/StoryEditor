using System;
using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public class EditContentWindow : EditorWindow
    {
        static Action<string> Save;
        public static void Open(Action<string> save, string context)
        {
            Save = save;
            var window = EditorWindow.GetWindow<EditContentWindow>();
            window.maxSize = new Vector2(500, 550);
            window.minSize = new Vector2(500, 550);
            window.context = context;
        }
        

        public string context = "Edit Window";
        Vector2 scrollPos = Vector2.one;
        private void OnGUI()
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(500), GUILayout.Height(500));
            context = GUILayout.TextArea(context, 10000);
            GUILayout.EndScrollView();

            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("取消"))
            {
                Close();
            }

            if (GUILayout.Button("保存"))
            {
                Save.Invoke(context);
                Close();
            }
            GUILayout.EndHorizontal();
        }
    }
}