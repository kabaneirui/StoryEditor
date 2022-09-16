#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace n.editor { 

    public class HorizontalDragableHandle : AbsDragableGUI
    {

        AbsPanel leftPanel;

        AbsPanel rightPanel;

        bool hasLeftPanel;

        bool hasRightPanel;

        float leftPanelStartX;

        float rightPanelEndX;



        public HorizontalDragableHandle(Rect rect,AbsPanel leftPanel = null, AbsPanel rightPanel = null) :base(rect)
        {
            LimitVerticleDrag = true;

            this.leftPanel = leftPanel;
            this.rightPanel = rightPanel;

            if (null == leftPanel) hasLeftPanel = false;
            else hasLeftPanel = true;

             if (null == rightPanel) hasRightPanel = false;
            else hasRightPanel = true;


        }

        public override void OnGUI() 
        {
            base.OnGUI();

            GUILayout.BeginArea(rect, GUI.skin.GetStyle("Box"));
            //GUILayout.BeginArea(rect, StoryWin.guiskin.GetStyle("Label"));

            GUILayout.EndArea();

            EditorGUIUtility.AddCursorRect(rect, MouseCursor.ResizeHorizontal);

        }

        protected override void OnDragStart()
        {
            if(hasLeftPanel) leftPanelStartX = leftPanel.GetRect().x;

            if(hasRightPanel) rightPanelEndX = rightPanel.GetRect().x + rightPanel.GetRect().width;

        }

        protected override void OnDragging()
        {
            float dragOffX = mouseOffsetV2.x;

            float handleCenterX = CenterX;

            if (dragOffX < 0)
                LimitLeft(dragOffX, handleCenterX);
            else
                LimitRight(dragOffX, handleCenterX);

        }


        void LimitLeft(float dragOffx, float handleCenterX)
        {
            if (!hasLeftPanel) return;


            float leftMinW = leftPanel.MinW;

            float lpanelW = handleCenterX - leftPanelStartX;

            if (lpanelW < leftMinW) 
            {
                return;
            }

            x = ox + mouseOffsetV2.x;

            //update handle pos
            rect = new Rect(x, y, ow, oh);

            //update leftPanle sclae
            var leftRect = leftPanel.GetRect();
            leftRect.width = lpanelW;
            leftPanel.SetRect(leftRect);

            Rect rightRect = rightPanel.GetRect();
            rightRect.x = handleCenterX;
            float rpanelW = rightPanelEndX - handleCenterX;
            rightRect.width = rpanelW;
            rightPanel.SetRect(rightRect);

        }

        void LimitRight(float dragOffx, float handleCenterX)
        {
            if (!hasRightPanel) return;

            var rightMinW = rightPanel.MinW;

            float rpanelW = rightPanelEndX - handleCenterX;

            if (rpanelW < rightMinW) 
            {
                return;
            }

            x = ox + mouseOffsetV2.x;

            //update handle pos
            rect = new Rect(x, y, ow, oh);

            //update leftPanle sclae
            Rect rightRect = rightPanel.GetRect();
            rightRect.x = handleCenterX;
            rightRect.width = rpanelW;
            rightPanel.SetRect(rightRect);

            var leftRect = leftPanel.GetRect();
            float lpanelW = handleCenterX - leftPanelStartX;
            leftRect.width = lpanelW;
            leftPanel.SetRect(leftRect);

        }

    }
}

#endif