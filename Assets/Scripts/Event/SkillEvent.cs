using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/SkillEventSO")]
public class SkillEvent : ScriptableObject
{
    public UnityAction<List<SkillData>> OnEventRaised;//当事件被调用
    public UnityAction<int> OnSkillUse;
    
    public void RaiseEvent(List<SkillData> skillData)
    {
        OnEventRaised?.Invoke(skillData);
    }

    public void SkillUsedEvent(int skillNum)
    {
        OnSkillUse?.Invoke(skillNum);
    }
}
