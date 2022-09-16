using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace n.editor
{
    public partial class ConditionData : ScriptableObject
    {
        
        [HorizontalGroup("context", Width = 0.8f)]
        [MultiLineProperty(10)]
        [LabelText("文本内容"), LabelWidth(80)]
        public string context = "edit context";

        [HorizontalGroup("context")]
        [Button(180)]
        public void EditContext()
        {
            EditContentWindow.Open((string text) => { context = text; }, context);
        }
        
        [HorizontalGroup("condition", Width = 320, LabelWidth = 80)]
        [ValueDropdown("conditonPresets")]
        [LabelText("设定条件"), Space(30)]
        public ConditonPresets conditionType;
        
        [HorizontalGroup("condition")]
        [ShowIf("conditionType", ConditonPresets.Custom)]
        [HideLabel, Space(30)]
        public int conditonId;

    }
    
}