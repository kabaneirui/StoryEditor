#if UNITY_EDITOR

using UnityEngine;
namespace n.editor
{
    public class AbsPanel:IGUI
    {
        Rect panelRect;

        public float DefaultW =100;

        public float DefaultH = 100;

        public float MinW = 10;

        public float MinH = 10;

        public void OnGUI()
        {
            GUILayout.BeginArea(panelRect,GUI.skin.GetStyle("Box"));
            Draw();
            GUILayout.EndArea();
        }

        public void SetRect(Rect rect) 
        {
            panelRect = rect;
        }

        public Rect GetRect() 
        {
            return panelRect;
        }

        protected virtual void Draw()
        {

        }

        public virtual void Init() 
        {
        
        }


        public virtual void Release()
        {

        }


    }
}

#endif