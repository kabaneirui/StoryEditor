using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace n.editor
{
    public enum ConnectionPointType { In, Out }

    public class ConnectionPoint 
    {
        public Rect rect;   

        public ConnectionPointType type;

        public NodeBase OwnerNode;
        public StoryTreePanel OwnerWindow; 

        private GUIStyle style;

        public ConnectionPoint(NodeBase owner, ConnectionPointType type, StoryTreePanel ownerWindow, GUIStyle pointStyle, Vector2 size)
        {
            this.OwnerNode = owner;
            this.type = type;
            this.OwnerWindow = ownerWindow;
            this.style = pointStyle;

            rect = new Rect(0, 0, size.x, size.y);
            rect.size /= ownerWindow.zoom;
        }

        public void Draw()
        {
            
            rect.x = OwnerNode.rect.x + (OwnerNode.rect.width * 0.5f) - rect.width * 0.5f;

            switch (type)
            {
                case ConnectionPointType.In:   
                    rect.y = OwnerNode.rect.y - rect.height;
                    break;

                case ConnectionPointType.Out:   
                    rect.y = OwnerNode.rect.y + OwnerNode.rect.height;
                    break;
            }

  
            if(GUI.Button(rect, "", style))
            {
                if (OwnerWindow.SelectingPoint == null)
                    OwnerWindow.SelectingPoint = this;
                else 
                {
                    if (OwnerWindow.SelectingPoint.type!=this.type)
                    {

                        if (this.type == ConnectionPointType.In)
                            OwnerWindow.connections.Add(new Connection(this, OwnerWindow.SelectingPoint, OwnerWindow));
                        else
                            OwnerWindow.connections.Add(new Connection(OwnerWindow.SelectingPoint, this, OwnerWindow));

                        OwnerWindow.SelectingPoint = null;
                    }
                }
            }
        }
    }

}
