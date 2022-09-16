using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace n.editor
{
    public partial class DialogData : ScriptableObject
    {
        #region DataScene
        
        /// <summary>
        /// 由策划填入编号，相同编号的对话将不重新加载【场景】和【模型】资源
        /// </summary>
        [TitleGroup("Dialog")]
        [TabGroup("Dialog/Split", "场景")]
        [LabelText("组Id")]
        public int groupId;
        
        /// <summary>
        /// 唯一【场景ID】，通过【场景表】中的场景ID来配置不同的场景
        /// </summary>
        [HorizontalGroup("Dialog/Split/场景/scene", LabelWidth = 80, Width = 320), Space(30)]
        [ValueDropdown("scenePresets")]
        [LabelText("场景")]
        public ScenePresets sceneType;
        
        [HorizontalGroup("Dialog/Split/场景/scene"), Space(30)]
        [ShowIf("sceneType", ScenePresets.Custom)]
        [HideLabel]
        public int sceneId;
        
        /// <summary>
        /// 唯一【音乐ID】，通过【音乐表】中的音乐ID来配置不同的场景
        /// </summary>
        [HorizontalGroup("Dialog/Split/场景/bgm", LabelWidth = 80, Width = 320), Space(30)]
        [ValueDropdown(("bgmPresets"))]
        [LabelText("背景音乐")]
        public BGMPresets bgmType;
        
        [HorizontalGroup("Dialog/Split/场景/bgm"), Space(30)]
        [ShowIf("bgmType", BGMPresets.Custom)]
        [HideLabel]
        public int bgmId;
        
        [HorizontalGroup("Dialog/Split/场景/bgmTime", 0.5f)]
        [HideIfGroup("Dialog/Split/场景/bgmTime/Start/bgmType", Value = BGMPresets.None)]
        [BoxGroup("Dialog/Split/场景/bgmTime/Start")]
        [HideLabel]
        public int bgmStartTime;
        
        [BoxGroup("Dialog/Split/场景/bgmTime/End")]
        [HideIfGroup("Dialog/Split/场景/bgmTime/End/bgmType", Value = BGMPresets.None)]
        [HideLabel]
        public int bgmEndTime;
        
        /// <summary>
        /// 唯一【特效ID】，通过【特效表】中的特效ID来配置不同的场景
        /// </summary>
        [HorizontalGroup("Dialog/Split/场景/fx", LabelWidth = 80, Width = 320), Space(30)]
        [ValueDropdown(("fxPresets"))]
        [LabelText("载入特效")]
        public FXPresets fxType;
        
        [HorizontalGroup("Dialog/Split/场景/fx"), Space(30)]
        [ShowIf("fxType", FXPresets.Custom)]
        [HideLabel]
        public int fxId;
        
        [HorizontalGroup("Dialog/Split/场景/fxTime", 0.5f)]
        [HideIfGroup("Dialog/Split/场景/fxTime/Start/fxType", Value = FXPresets.None)]
        [BoxGroup("Dialog/Split/场景/fxTime/Start")] 
        [HideLabel]
        public int fxStartTime;
        
        [HideIfGroup("Dialog/Split/场景/fxTime/End/fxType", Value = FXPresets.None)]
        [BoxGroup("Dialog/Split/场景/fxTime/End")]
        [HideLabel]
        public int fxEndTime;
        
        /// <summary>
        /// 由分镜师提供的多种震动强度，强度参数由分镜进行封装，不可自定义
        /// </summary>
        [TabGroup("Dialog/Split", "场景")]
        [ValueDropdown("shakePresets")]
        [LabelText("震动效果"), LabelWidth(80), Space(30)]
        public ShakePresets shakeType;
        
        [HorizontalGroup("Dialog/Split/场景/shakeTime", 0.5f)]
        [HideIfGroup("Dialog/Split/场景/shakeTime/Start/shakeType", Value = ShakePresets.None)]
        [BoxGroup("Dialog/Split/场景/shakeTime/Start")]
        [HideLabel]
        public int shakeStartTime;
        
        [HideIfGroup("Dialog/Split/场景/shakeTime/End/shakeType", Value = ShakePresets.None)]
        [BoxGroup("Dialog/Split/场景/shakeTime/End")]
        [HideLabel]
        public int shakeEndTime;
        
        /// <summary>
        /// 由分镜师提供的多种镜头配置，配置参数由分镜进行封装，不可自定义
        /// </summary>
        [TabGroup("Dialog/Split", "场景")]
        [ValueDropdown("lensPresets")]
        [LabelText("镜头"), LabelWidth(80), Space(30)]
        public LensPresets lensType;
        
        /// <summary>
        /// 与美术协调讨论，需要用到的转场动画类型
        /// </summary>
        [TabGroup("Dialog/Split", "场景")]
        [ValueDropdown("transitPresets")]
        [LabelText("转场动画"), LabelWidth(80), Space(30)]
        public TransitPresets transitType;
        
        [HorizontalGroup("Dialog/Split/场景/toggle", LabelWidth = 80, Width = 200), Space(30)]
        [LabelText("自动")]
        public bool aoto;
        
        [HorizontalGroup("Dialog/Split/场景/toggle", LabelWidth = 80, Width = 200), Space(30)]
        [LabelText("跳过")]
        public bool jump;
        
        #endregion
        
        
        #region DataContent
        
        [TabGroup("Dialog/Split", "内容")]
        [HorizontalGroup("Dialog/Split/内容/Text")]
        [MultiLineProperty(10)]
        [HideLabel]
        public string context = "edit window";

        [Button(180)]
        [HorizontalGroup("Dialog/Split/内容/Text")]
        public void EditContent()
        {
            EditContentWindow.Open((string text) => { context = text; }, context);
        }

        [HorizontalGroup("Dialog/Split/内容/dialog", Width = 320, LabelWidth = 80), Space(30)]
        [ValueDropdown("dialogPresets")]
        [LabelText("对话框")]
        public DialogPreset dialogType;
        
        [HorizontalGroup("Dialog/Split/内容/dialog"), Space(30)]
        [ShowIf("dialogType", DialogPreset.Custom)]
        [HideLabel]
        public int dialogId;
        
        [TabGroup("Dialog/Split","内容")]
        [LabelText("配音资源"), LabelWidth(80), Space(30)]
        public int audio;
        
        
        
        public struct Charactor
        {
            [Title("出场对象")]
            [LabelText("是否主角"), LabelWidth(80)]
            public bool main;
            
            public int charId;
            
            public int action;
            public int pos;
        }
        
        public Charactor[] chars = new Charactor[2];
        
        #endregion


    }
}