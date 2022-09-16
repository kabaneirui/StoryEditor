#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine;

namespace n.editor
{
    public class HorizontalPanelContainer : IGUI
    {
        public enum LayoutEnum 
        {
            verticle,
            horizontal
        }

        List<AbsPanel> panelList;

        List<HorizontalDragableHandle> handleList;

        Rect containerRect;

        float panelSpaceW=4f;

        float defaultPanelW = 10F;

        bool bNeedUpdateLayout = false;

        public HorizontalPanelContainer() 
        {
            panelList = new List<AbsPanel>();
            //Init();
        }

        public void Set(Rect rect, float panelSpaceW,float defaultPanelW) 
        {
            this.panelSpaceW = panelSpaceW;
            this.containerRect = rect;
            this.defaultPanelW = defaultPanelW;
            bNeedUpdateLayout = true;
        }

        public void Init() 
        {

            handleList = new List<HorizontalDragableHandle>();

            int count = panelList.Count;

            for (int i = 0; i < count; i++)
            {
                panelList[i].Init();
            }
        }

        public void Release() 
        {
            if (null != panelList) 
            {
                int count = panelList.Count;
                for (int i = 0; i < count; i++)
                {
                    panelList[i].Release();
                }
                panelList.Clear();
            
            }

            int size = handleList.Count;
            for (int i = 0; i < size; i++)
            {
                handleList[i].Release();
            }
            handleList.Clear();

        }

        public void RegisterPanel(AbsPanel panel) 
        {
            panelList.Add(panel);
        }

        public void OnGUI()
        {
            //Debug.Log($"更新:{bNeedUpdateLayout}");
            if (bNeedUpdateLayout) 
            {
                //Debug.Log("更新");
                UpdateLayout();
                bNeedUpdateLayout = false;
            }

            int count = panelList.Count;

            for (int i = 0; i < count; i++)
            {
                panelList[i].OnGUI();
                //NTODO happy DrawHandle
            }

            count = handleList.Count;
            for (int i = 0; i < count; i++)
            {
                handleList[i].OnGUI();
            }

        }

        public void UpdateLayout() 
        {
            CaculateH();
        }

        //NINFO happy 后续拖动后，无论窗口大小，都按这个规则
        //或者用临时变量记录初始值，变化后使用临时变量记录的当前值
        void CaculateH()
        {
            Rect rect = new Rect();

            int count = panelList.Count;

            float offsetX = 0;

            for (int i = 0; i < count; i++)
            {
                bool bLastPanel = (i == count - 1);

                var curPanel = panelList[i];
                rect.x = offsetX;
                rect.y = containerRect.y;

                if (curPanel.DefaultW != 0)
                {
                    if (bLastPanel)
                    {
                        //最后一个拉到最后
                        rect.width = containerRect.width - offsetX - panelSpaceW;
                        Debug.Log($"[nafio] i:{i} w1:{rect.width}");
                    }
                    else
                    {
                        rect.width = curPanel.DefaultW;
                        Debug.Log($"[nafio] i:{i} w2:{rect.width}");
                    }

                }
                else 
                {
                    rect.width = defaultPanelW;
                    Debug.Log($"[nafio] i:{i} w3:{rect.width}");
                }
                    


                rect.height = containerRect.height;

                curPanel.SetRect(rect);

                offsetX = offsetX + curPanel.GetRect().width + panelSpaceW;


            }//for end


            //setup handle
            count--;//handleNum = panleNum-1
            for (int i = 0; i < count; i++)
            {
                var curPanel = panelList[i];
                var nextPanel = panelList[i+1];

                rect = curPanel.GetRect();
                float handleY = containerRect.y;

                //float handleX = x + 0.5F * panelSpaceW - 0.5F * StoryDefault.HANDLE_WIDTH ;
                float handleX = rect.x + rect.width + 0.5F * (panelSpaceW - StoryDefault.HANDLE_WIDTH) ;

                //Debug.Log($"[nafio] i:{i} handleX:{handleX} handleY:{handleY} w:{StoryDefault.HANDLE_WIDTH} h:{containerRect.height}");
                var handle = new HorizontalDragableHandle(new Rect(handleX, handleY, StoryDefault.HANDLE_WIDTH, containerRect.height), curPanel, nextPanel);

                handleList.Add(handle);

            }//for end

        }//CaculateH() end

    }//class end

}//namespace end

#endif
