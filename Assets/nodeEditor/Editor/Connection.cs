using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace n.editor
{
    public class Connection 
    {
        public ConnectionPoint inPoint; 
        public ConnectionPoint outPoint; 

        public StoryTreePanel OwnerWindow;

        public Connection(ConnectionPoint inPoint, ConnectionPoint outPoint, StoryTreePanel owner)
        {
            this.inPoint = inPoint;
            this.outPoint = outPoint;
            this.OwnerWindow = owner;
        }

        public void Draw()
        {
            Handles.DrawBezier( 
                inPoint.rect.center,    //startPosition
                outPoint.rect.center,   //endPosition
                inPoint.rect.center + Vector2.left * 1f,   //startTangent
                outPoint.rect.center - Vector2.left * 1f,  //endTangent	
                Color.white,        //color
                null,         //texture
                3f             //width
            );
    
            if(OwnerWindow.isRemoveConnectionMode)
            {
                Vector2 buttonSize = new Vector2(20, 20);
                Vector2 LineCenter = (inPoint.rect.center + outPoint.rect.center) / 2;
                if (GUI.Button(new Rect(LineCenter - buttonSize / 2, buttonSize), "X"))
                    OwnerWindow.connections.Remove(this);
            }
        }
    }
}


