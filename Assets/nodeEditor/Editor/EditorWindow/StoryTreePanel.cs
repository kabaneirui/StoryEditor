using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace n.editor
{
    public partial class StoryTreePanel : AbsPanel
    {
        private List<NodeBase> nodes;           //节点列表
        public List<Connection> connections;    //连接列表

        public ConnectionPoint SelectingPoint;  //记录正在选择的点，用于判断之后是否会发生连接
        public bool isRemoveConnectionMode;     //标志着是否进入移除连线模式

        //记录一些GUIStyle
        GUIStyle style_Node;            //节点的GUI风格
        GUIStyle style_Node_select;     //节点在选择情况下的GUI风格
        GUIStyle style_Point;           //连接点的GUI风格

        #region param

        private float maxZoom = 2f;
        private float minZoom = 1f;
        
        private float _zoom = 1;
        public float zoom { get { return _zoom; } set { _zoom = Mathf.Clamp(value, minZoom, maxZoom);  } }
        
        private Vector2 _panOffset;
        private Vector2 panOffset { get { return _panOffset; } set { _panOffset = value;  } }
        
        #endregion
        
        /// <summary>
        /// EditorWindow的接口OnEnable：当对象加载时调用此函数
        /// </summary>
        public override void Init()
        {
            DefaultW = 600;
            MinW = 300;
            
            //创建节点列表对象
            nodes = new List<NodeBase>();
            //创建连接列表对象
            connections = new List<Connection>();
        }

        /// <summary>
        /// 鼠标右键菜单：
        /// </summary>
        /// <param name="mousePosition"></param>
        private void RightMouseMenu(Vector2 mousePosition)
        {
            //创建菜单对象
            GenericMenu genericMenu = new GenericMenu();
            //菜单加一项 Add node
            genericMenu.AddItem(new GUIContent("添加条件"), false, () => ProcessAddNode<NodeCondition>(mousePosition));
            genericMenu.AddItem(new GUIContent("添加对话"), false, () => ProcessAddNode<NodeDialog>(mousePosition));
            //显示菜单
            genericMenu.ShowAsContext();
        }

        /// <summary>
        /// 处理添加节点
        /// </summary>
        /// <param name="nodePosition"></param>
        /// <typeparam name="T"></typeparam>
        private void ProcessAddNode<T>(Vector2 nodePosition) where T : NodeBase
        {
            NodeBase node = null;
            if (typeof(T) == typeof(NodeCondition))
            {
                node = new NodeCondition(nodePosition, this);
            }
            else if (typeof(T) == typeof(NodeDialog))
            {
                node = new NodeDialog(nodePosition, this);
            }
            
            nodes.Add(node);
        }
        /// <summary>
        /// 处理移除节点
        /// </summary>
        /// <param name="node"></param>
        public void ProcessRemoveNode(NodeBase node)
        {
            //收集“待删除连接列表”
            List<Connection> connectionsToRemove = new List<Connection>();

            //遍历所有的连接，若连接的入点或出点是属于要删除的节点的，则将其添加到“待删除连接列表”中
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i].inPoint == node.inPoint || connections[i].outPoint == node.outPoint)
                    connectionsToRemove.Add(connections[i]);
            }

            //删除“待删除连接列表”中所有连接
            for (int i = 0; i < connectionsToRemove.Count; i++)
                connections.Remove(connectionsToRemove[i]);

            connectionsToRemove = null;

            //移除节点
            nodes.Remove(node);
        }

    }

}
