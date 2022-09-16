#if UNITY_EDITOR
using UnityEngine;

namespace n.editor
{
    public class AbsDragableGUI : IGUI
    {
        protected bool bDragging;

        protected Vector2 mouseDownV2;

        protected Vector2 mouseOffsetV2= new Vector2(0,0);

        protected Rect rect;

        protected float ox;
        protected float oy;
        protected float ow;
        protected float oh;

        protected float x;
        protected float y;

        public bool LimitHorizontalDrag = false;

        public bool LimitVerticleDrag = false;

        public AbsDragableGUI(Rect rect)
        {
            this.rect = rect;

            Init();
        }

        public bool Dragging
        {
            get
            {
                return bDragging;
            }
        }

        public float CenterX 
        {
            get 
            {
                float centerX = x + ow * 0.5f;
                return centerX;
            }

        }

        public float CenterY 
        {
            get 
            {
                float centerY = y + oh * 0.5f;
                return centerY;
            }
        }

        public virtual void Init()
        {
            ox = rect.x;
            oy = rect.y;
            ow = rect.width;
            oh = rect.height;

            x = ox;
            y = oy;
        }

        public virtual void OnGUI()
        {
            Drag();
        }

        public virtual void Release()
        {
            ox = 0;
            oy = 0;
            ow = 1;
            oh = 1;
            x = ox;
            y = oy;
        }

        void Drag()
        {
            if (null == Event.current) return;

            switch (Event.current.rawType)
            {
                
                case EventType.MouseDown:

                    if (rect.Contains(Event.current.mousePosition)) 
                    {
                        mouseDownV2 = Event.current.mousePosition;
                        mouseOffsetV2= Vector2.zero;
                        bDragging = true;

                        OnDragStart();
                    }
                  
                    break;

                case EventType.MouseDrag:
                    if (bDragging)
                    {
                        mouseOffsetV2 = Event.current.mousePosition - mouseDownV2;
                        OnDragging();
                    }
                    break;

                case EventType.MouseUp:
                    if (bDragging) 
                    {
                        bDragging = false;
                        ox = x;
                        oy = y;
                        OnDragEnd();
                    }
                    break;
            }

        }
        protected virtual void OnDragStart() 
        {
            
        }

        protected virtual void OnDragging() 
        {
            //if (!bDragging) return;

            if (!LimitHorizontalDrag) 
            {
                x = ox + mouseOffsetV2.x;
                //Debug.Log($"[nafio] x:{x} ox:{ox} offx:{mouseOffsetV2.x}");
            }

            if (!LimitVerticleDrag)
                y = oy + mouseOffsetV2.y;


            rect = new Rect(x, y, ow, oh);

            //NTODO happy 能对外发出么，drag完必须刷新，否则就只能拖拽完看到panel瞬移
            //Repaint();

            //Debug.Log($"x:{x} y:{y}  rect:{rect}");

        }

        protected virtual void OnDragEnd() 
        {
            
        }


    }

}
#endif