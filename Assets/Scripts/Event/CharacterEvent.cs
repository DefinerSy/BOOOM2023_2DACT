using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEvent : ScriptableObject
{
    public UnityAction<Character> OnEventRaised;//当事件被调用
    public UnityAction OnDashRaised;//冲刺事件
    
    public void RaiseEvent(Character character)
    {
        OnEventRaised?.Invoke(character);
    }

    public void DashRaisedEvent()
    {
        OnDashRaised?.Invoke();
    }
    
}
