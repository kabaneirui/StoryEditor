using System;
using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public class NodeDialog : NodeBase
    {

        #region Texture

        public static Texture2D dot { get { return _dot != null ? _dot : _dot = Resources.Load<Texture2D>("xnode_dot"); } }
        private static Texture2D _dot;
    
        public static Texture2D dotOuter { get { return _dotOuter != null ? _dotOuter : _dotOuter = Resources.Load<Texture2D>("xnode_dot_outer"); } }
        private static Texture2D _dotOuter;
    
        public static Texture2D body { get { return _body != null ? _body : _body = Resources.Load<Texture2D>("xnode_node"); } }
        private static Texture2D _body;
    
        public static Texture2D bodyHighlight { get { return _bodyHighlight != null ? _bodyHighlight : _bodyHighlight = Resources.Load<Texture2D>("xnode_node_highlight"); } }
        private static Texture2D _bodyHighlight;


        #endregion
     
        public NodeDialog(Vector2 position, StoryTreePanel owner, DialogData data = null) : base(position, owner)
        {
            if (data != null)
                this.data = data;
            else
                data = ScriptableObject.CreateInstance<DialogData>();

            editor = Editor.CreateEditor(data);
        }
    
        protected override void InitStyle()
        {
            name = "对话";
        
            size.x = 128;
            size.y = 36;
        
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
        
        }
    }
}

