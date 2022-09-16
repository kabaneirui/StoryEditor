using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public partial class StoryTreePanel 
    {
        private Color line = new Color(.23f, .23f, .23f);
        private Color bg = new Color(.19f, .19f, .19f);
        
        private Texture2D _gridTex;
        Texture2D gridTex
        {
            get
            {
                if (_gridTex == null)
                    _gridTex = GenerateGridTexture(line, bg);
                return _gridTex;
            }
        }

        private Texture2D _crossTex;
        Texture2D crossTex
        {
            get
            {
                if (_crossTex == null)
                    _crossTex = GenerateCrossTexture(line);
                return _crossTex;
            }
        }
        
        /// <summary>
        /// EditorWindow的接口OnGUI：绘制控件调用的接口
        /// </summary>
        protected  override void Draw()
        {
            // GUILayout.BeginArea(new Rect(leftWidth, 0, position.width - leftWidth - rightWidth, position.height));

            //绘制背景画布网格
            DrawGrid(GetRect(), zoom, panOffset);

            //绘制节点和连线
            DrawNodes();
            DrawConnections();

            //处理事件
            ProcessNodeEvents(Event.current);   //先处理节点的
            ProcessEvents(Event.current);       //再处理自身的
            
            //绘制待连接线
            DrawPendingConnection(Event.current);
        
            // GUILayout.EndArea();
            
        }

        public Texture2D GenerateGridTexture(Color line, Color bg)
        {
            Texture2D tex = new Texture2D(64, 64);
            Color[] cols = new Color[64 * 64];
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                {
                    Color col = bg;
                    if (y % 16 == 0 || x % 16 == 0) col = Color.Lerp(line, bg, 0.65f);
                    if (y == 63 || x == 63) col = Color.Lerp(line, bg, 0.35f);
                    cols[y * 64 + x] = col;
                }
            }

            tex.SetPixels(cols);
            tex.wrapMode = TextureWrapMode.Repeat;
            tex.filterMode = FilterMode.Bilinear;
            tex.name = "Grid";
            tex.Apply();

            return tex;
        }

        public Texture2D GenerateCrossTexture(Color line)
        {
            Texture2D tex = new Texture2D(64, 64);
            Color[] cols = new Color[64 * 64];
            for (int y = 0; y < 64; y++)
            {
                for (int x = 0; x < 64; x++)
                {
                    Color col = line;
                    if (y != 31 && x != 31) col.a = 0;
                    cols[y * 64 + x] = col;
                }
            }

            tex.SetPixels(cols);
            tex.wrapMode = TextureWrapMode.Repeat;
            tex.filterMode = FilterMode.Bilinear;
            tex.name = "Grid";
            tex.Apply();
            
            return tex;
        }
        
        private void DrawGrid(Rect rect, float zoom, Vector2 panOffset)
        {
            rect.position = Vector2.zero;

            Vector2 center = rect.size / 2f;

            // Offset from origin in tile units
            float xOffset = -(center.x * zoom + panOffset.x) / gridTex.width;
            float yOffset = ((center.y - rect.size.y) * zoom + panOffset.y) / gridTex.height;
            Vector2 tileOffset = new Vector2(xOffset, yOffset);
            
            // Amount of tiles
            float tileAmountX = Mathf.Round(rect.size.x * zoom) / gridTex.width;
            float tileAmountY = Mathf.Round(rect.size.y * zoom) / gridTex.height;
            Vector2 tileAmount = new Vector2(tileAmountX, tileAmountY);
            
            // Draw tiled background
            GUI.DrawTextureWithTexCoords(rect, gridTex, new Rect(tileOffset, tileAmount));
            GUI.DrawTextureWithTexCoords(rect, crossTex, new Rect(tileOffset + new Vector2(.5f, .5f), tileAmount));
        }

        /// <summary>
        /// 绘制所有节点
        /// </summary>
        private void DrawNodes()
        {
            for (int i = 0; i < nodes.Count; i++)
                nodes[i].Draw();      
        }
        
        /// <summary>
        /// 绘制所有的连线
        /// </summary>
        private void DrawConnections()
        {
            for (int i = 0; i < connections.Count; i++)
                connections[i].Draw();
        }
        
        /// <summary>
        /// 绘制待连接线
        /// </summary>
        /// <param name="e"></param>
        private void DrawPendingConnection(Event e)
        {
            var pos = e.mousePosition;
            if(SelectingPoint != null)//如果已经选择了一个连接点，则画出待连接的线
            {
                //贝塞尔曲线的起点，根据已选则点的方向做判断：
                Vector3 startPosition = (SelectingPoint.type == ConnectionPointType.In) ? SelectingPoint.rect.center : pos;
                Vector3 endPosition = (SelectingPoint.type == ConnectionPointType.In) ? pos : SelectingPoint.rect.center;

                Handles.DrawBezier(     //绘制通过给定切线的起点和终点的纹理化贝塞尔曲线
                    startPosition,  
                    endPosition,            
                    startPosition + Vector3.left * 1f, //startTangent	贝塞尔曲线的起始切线。
                    endPosition - Vector3.left * 1f,   //endTangent	贝塞尔曲线的终点切线。
                    Color.white,        //color	    要用于贝塞尔曲线的颜色。
                    null,               //texture	要用于绘制贝塞尔曲线的纹理。
                    2f                  //width	    贝塞尔曲线的宽度。
                );

                GUI.changed = true;
            }
        }

    }
}

