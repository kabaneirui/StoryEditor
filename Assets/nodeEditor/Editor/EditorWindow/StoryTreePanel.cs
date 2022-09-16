using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace n.editor
{
    public partial class StoryTreePanel : AbsPanel
    {
        private List<NodeBase> nodes;           //�ڵ��б�
        public List<Connection> connections;    //�����б�

        public ConnectionPoint SelectingPoint;  //��¼����ѡ��ĵ㣬�����ж�֮���Ƿ�ᷢ������
        public bool isRemoveConnectionMode;     //��־���Ƿ�����Ƴ�����ģʽ

        //��¼һЩGUIStyle
        GUIStyle style_Node;            //�ڵ��GUI���
        GUIStyle style_Node_select;     //�ڵ���ѡ������µ�GUI���
        GUIStyle style_Point;           //���ӵ��GUI���

        #region param

        private float maxZoom = 2f;
        private float minZoom = 1f;
        
        private float _zoom = 1;
        public float zoom { get { return _zoom; } set { _zoom = Mathf.Clamp(value, minZoom, maxZoom);  } }
        
        private Vector2 _panOffset;
        private Vector2 panOffset { get { return _panOffset; } set { _panOffset = value;  } }
        
        #endregion
        
        /// <summary>
        /// EditorWindow�Ľӿ�OnEnable�����������ʱ���ô˺���
        /// </summary>
        public override void Init()
        {
            DefaultW = 600;
            MinW = 300;
            
            //�����ڵ��б����
            nodes = new List<NodeBase>();
            //���������б����
            connections = new List<Connection>();
        }

        /// <summary>
        /// ����Ҽ��˵���
        /// </summary>
        /// <param name="mousePosition"></param>
        private void RightMouseMenu(Vector2 mousePosition)
        {
            //�����˵�����
            GenericMenu genericMenu = new GenericMenu();
            //�˵���һ�� Add node
            genericMenu.AddItem(new GUIContent("�������"), false, () => ProcessAddNode<NodeCondition>(mousePosition));
            genericMenu.AddItem(new GUIContent("��ӶԻ�"), false, () => ProcessAddNode<NodeDialog>(mousePosition));
            //��ʾ�˵�
            genericMenu.ShowAsContext();
        }

        /// <summary>
        /// ������ӽڵ�
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
        /// �����Ƴ��ڵ�
        /// </summary>
        /// <param name="node"></param>
        public void ProcessRemoveNode(NodeBase node)
        {
            //�ռ�����ɾ�������б�
            List<Connection> connectionsToRemove = new List<Connection>();

            //�������е����ӣ������ӵ��������������Ҫɾ���Ľڵ�ģ�������ӵ�����ɾ�������б���
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i].inPoint == node.inPoint || connections[i].outPoint == node.outPoint)
                    connectionsToRemove.Add(connections[i]);
            }

            //ɾ������ɾ�������б�����������
            for (int i = 0; i < connectionsToRemove.Count; i++)
                connections.Remove(connectionsToRemove[i]);

            connectionsToRemove = null;

            //�Ƴ��ڵ�
            nodes.Remove(node);
        }

    }

}
