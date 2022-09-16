using System;
using UnityEngine;
using UnityEditor;

namespace n.editor
{
    public abstract class NodeBase
    {

        protected ScriptableObject data;
        protected Editor editor;
        
        public string name = "Node";

        public int id = 0;
        
        public Rect rect;

        public StoryTreePanel window;

        private bool isDragged;
        private bool isSelected;

        public ConnectionPoint inPoint;
        public ConnectionPoint outPoint;

        #region Style

        protected GUIStyle style;          
        protected GUIStyle style_select;   
        protected GUIStyle style_inputPot; 
        protected GUIStyle style_outputPot;

        #endregion


        protected Vector2 size = new Vector2(160, 40);
        protected Vector2 pointSize = new Vector2(16, 16);

        /// <summary>
        /// Must Override
        /// </summary>
        protected virtual void InitStyle(){ }
        
        public NodeBase( Vector2 position, StoryTreePanel owner ) 
        {
            InitStyle();
            rect = new Rect(position.x, position.y, size.x, size.y);
            rect.size /= owner.zoom;
            window = owner;
            
            inPoint = new ConnectionPoint(this, ConnectionPointType.In, owner, style_inputPot, pointSize);
            outPoint = new ConnectionPoint(this, ConnectionPointType.Out, owner, style_outputPot, pointSize);
        }
        
        public void Draw()
        {
            GUI.Box(rect, name + "-" + id, isSelected ? style_select : style);
            inPoint.Draw();
            outPoint.Draw();
        }
        
        public bool ProcessEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 0)
                    {
                        if (rect.Contains(e.mousePosition))
                        {
                            isDragged = true;
                            isSelected = true;
                            StoryInspectPanel.NodeEditor = editor;
                        }
                        else
                        {
                            isSelected = false;
                        }

                        GUI.changed = true;
                    }
                    if (e.button == 1)
                    {
                        if(isSelected && rect.Contains(e.mousePosition))
                        {
                            RightMouseMenu();
                            e.Use();
                        }
                        
                    }
                    break;
                case EventType.MouseUp:
                    isDragged = false;
                    break;
                case EventType.MouseDrag:
                    if (e.button == 0 && isDragged)
                    {
                        ProcessDrag(e.delta);
                        e.Use();
                        return true;
                    }
                    break;
            }
            return false;
        }
        
        public void ProcessDrag(Vector2 delta)
        {
            rect.position += delta;
        }
        
        public void ProcessScroll(float deltaZoom, Vector2 mousePosition)
        {
            var delta = (1 - deltaZoom) * (rect.position - mousePosition);
            rect.position -= delta;
            rect.size  *= deltaZoom;
            inPoint.rect.size *= deltaZoom;
            outPoint.rect.size *= deltaZoom;
        }
        
        protected void RightMouseMenu()
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Remove node"), false, () => 
            {
                if (editor == StoryInspectPanel.NodeEditor)
                    StoryInspectPanel.NodeEditor = null;
                window.ProcessRemoveNode(this);
            });
            genericMenu.ShowAsContext();
        }
    }
}

