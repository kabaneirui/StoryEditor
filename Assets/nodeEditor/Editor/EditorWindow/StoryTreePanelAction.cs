using n.editor;
using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public partial class StoryTreePanel
    {

        private float dragThreshold = 1f;

        public Vector2 WindowToGridPosition(Vector2 windowPosition) {
            return (windowPosition - (GetRect().size * 0.5f) - (panOffset / zoom)) * zoom;
        }
        
        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="e"></param>
        private void ProcessEvents(Event e)
        {
            switch (e.type)//根据事件类型做判断
            {
                case EventType.MouseDown:   //按下鼠标键
                    if (e.button == 1)      //鼠标右键
                    {
                        //触发菜单
                        RightMouseMenu(e.mousePosition);
                    }
                    if (e.button == 0)  //按下鼠标左键
                    {
                        SelectingPoint = null;//清空当前所选的连接点
                    }
                    break;
                case EventType.KeyDown://按下键盘
                    if (e.keyCode == KeyCode.Y)//是Y键
                    {
                        isRemoveConnectionMode = true;  //进入移除连线模式
                        GUI.changed = true;             //提示需要刷新GUI
                    }
                    break;
                case EventType.KeyUp://松开键盘
                    if (e.keyCode == KeyCode.Y)//是Y键
                    {
                        isRemoveConnectionMode = false; //离开移除连线模式
                        GUI.changed = true;             //提示需要刷新GUI
                    }
                    break;
                case EventType.MouseDrag:   //鼠标拖拽
                    if(e.button == 0 || e.button == 2)          //鼠标左键,滚轮键
                    {
                        if (e.delta.magnitude > dragThreshold)
                        {
                            DragAllNodes(e.delta);              //拖拽所有节点（拖拽画布）
                            panOffset += e.delta * zoom;        //增加画布网格的偏移
                            GUI.changed = true;                 //提示需要刷新GUI
                        }
                    }
                    break;
                case EventType.ScrollWheel:
                    float oldZoom = zoom;
                    if (e.delta.y > 0) zoom += 0.1f * zoom;
                    else zoom -= 0.1f * zoom;
                    panOffset += (1 - oldZoom / zoom) * (WindowToGridPosition(e.mousePosition) + panOffset);
                    ScrollAllNodes( oldZoom / zoom, e.mousePosition );  //拖拽所有节点（拖拽画布）
                    break;
            }
        }

        /// <summary>
        /// 处理所有节点的事件
        /// </summary>
        /// <param name="e"></param>
        private void ProcessNodeEvents(Event e)
        {
            //降序处理所有节点的事件（之所以降序是因为后画的节点将显示在更上层）
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                //处理每个节点的事件并看是否发生了拖拽
                bool DragHappend = nodes[i].ProcessEvents(e);
                //若发生了拖拽则提示GUI发生变化
                if (DragHappend)
                    GUI.changed = true;
            }
        }

        
        /// <summary>
        /// 拖拽所有节点（拖拽画布）
        /// </summary>
        /// <param name="delta"></param>
        private void DragAllNodes(Vector2 delta)
        {
            for (int i = 0; i < nodes.Count; i++)
                nodes[i].ProcessDrag(delta);
        }

        private void ScrollAllNodes(float deltaZoom, Vector2 mousePosition)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].ProcessScroll(deltaZoom, mousePosition);
            }
                
        }

    }
}

