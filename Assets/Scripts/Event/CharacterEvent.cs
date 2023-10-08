using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEvent : ScriptableObject
{
    public UnityAction<Character,int> OnEventRaised;//当事件被调用
    public UnityAction OnDashRaised;//冲刺事件
    
    public void RaiseEvent(Character character,int Damage)
    {
        OnEventRaised?.Invoke(character,Damage);
    }

    public void DashRaisedEvent()
    {
        OnDashRaised?.Invoke();
    }
    
}
