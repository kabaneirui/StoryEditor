#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public class StoryWin : EditorWindow
    {

        static HorizontalPanelContainer Container;


        static bool BFirstOnGUI = true;

        //public static GUISkin guiskin;

        [MenuItem("Tools/EditorWin/HappyEditor")]
        public static void ShowWindow()
        {
            var storyListPanel = new StoryListPanel();
            var storyTreePanel = new StoryTreePanel();
            var inspectPanel = new StoryInspectPanel();

            Container = new HorizontalPanelContainer();
            Container.RegisterPanel(storyListPanel);
            Container.RegisterPanel(storyTreePanel);
            Container.RegisterPanel(inspectPanel);

            var win = EditorWindow.GetWindow(typeof(StoryWin));
            win.autoRepaintOnSceneChange = true;
            win.minSize = new Vector2(1080,720);


            //guiskin = AssetDatabase.LoadAssetAtPath<GUISkin>(StoryDefault.GUISKIN_PATH);
        }

        void OnGUI()
        {

            //GUI.skin = guiskin;

            if (BFirstOnGUI)
            {
                BFirstOnGUI = false;
                FirstOnGUI();
            }

            DrawTopBtn();
            
            Container.OnGUI();

            //dragableHandle.OnGUI();

            //没这个，拖动时不刷新显示
            Repaint();

        }

        private void OnDestroy()
        {
            BFirstOnGUI = true;
            Container.Release();
            //dragableHandle.Release();
        }

        //protected override void OnBackingScaleFactorChanged() 
        //{
        //    Debug.Log($"[nafio] w:{position.width} h:{position.height}");
        //}


        void FirstOnGUI() 
        {

            Container.Set(new Rect(0, StoryDefault.TOP_MENU_HEIGHT, position.width, position.height), StoryDefault.PANEL_SPACE, 8f);

            Container.Init();
        }


        void DrawTopBtn()
        {
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("导入",GUILayout.Width(200),GUILayout.Height(40)))
            {
            }

            if (GUILayout.Button("导出", GUILayout.Width(200), GUILayout.Height(40)))
            {
            }

            if (GUILayout.Button("更新", GUILayout.Width(200), GUILayout.Height(40)))
            {
            }

            if (GUILayout.Button("上传", GUILayout.Width(200), GUILayout.Height(40)))
            {
            }

            GUILayout.EndHorizontal();
        }


    }

}


#endif