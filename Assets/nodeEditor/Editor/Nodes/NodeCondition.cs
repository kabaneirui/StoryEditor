
using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public class NodeCondition : NodeBase
    {
        #region Texture

        public static Texture2D dot { get { return _dot != null ? _dot : _dot = Resources.Load<Texture2D>("xnode_dot"); } }
        private static Texture2D _dot;
        
        public static Texture2D dotOuter { get { return _dotOuter != null ? _dotOuter : _dotOuter = Resources.Load<Texture2D>("xnode_dot_outer"); } }
        private static Texture2D _dotOuter;
        
        public static Texture2D body { get { return _body != null ? _body : _body = Resources.Load<Texture2D>("xnode_node_2"); } }
        private static Texture2D _body;
        
        public static Texture2D bodyHighlight { get { return _bodyHighlight != null ? _bodyHighlight : _bodyHighlight = Resources.Load<Texture2D>("xnode_node_2_highlight"); } }
        private static Texture2D _bodyHighlight;

        #endregion


        public NodeCondition(Vector2 position, StoryTreePanel owner) : base(position, owner)
        {
            data = ScriptableObject.CreateInstance<ConditionData>();
            editor = Editor.CreateEditor(data);
        }

        protected override void InitStyle()
        {
            name = "条件";
            
            size.x = 80;
            size.y = 56;
            
            GUIStyle baseStyle = new GUIStyle("Label");

            style_inputPot = new GUIStyle(baseStyle);
            style_inputPot.alignment = TextAnchor.UpperCenter;
            style_inputPot.padding.top = 0;
            style_inputPot.active.background = dot;
            style_inputPot.normal.background = dotOuter;

            style_outputPot = new GUIStyle(baseStyle);
            style_outputPot.alignment = TextAnchor.LowerCenter;
            style_outputPot.padding.bottom = 0;
            style_outputPot.active.background = dot;
            style_outputPot.normal.background = dotOuter;

            style = new GUIStyle();
            style.normal.background = body;
            style.alignment = TextAnchor.MiddleCenter;

            style_select = new GUIStyle();
            style_select.normal.background = bodyHighlight;
            style_select.alignment = TextAnchor.MiddleCenter;
            style_select.fontStyle = FontStyle.Bold;

            // //连接点的风格：
            // style_Point = new GUIStyle();
            // //normal：       正常显示组件时的渲染设置
            // style_Point.normal.background = EditorGUIUtility.Load($"{texRoot}/point_normal.png") as Texture2D;
            // //active：       按下控件时的渲染设置。
            // style_Point.active.background = EditorGUIUtility.Load($"{texRoot}/point_active.png") as Texture2D;
            // //hover：        鼠标悬停在控件上时的渲染设置。
            // style_Point.hover.background = EditorGUIUtility.Load($"{texRoot}/point_hover.png") as Texture2D;
        }
    }
}

