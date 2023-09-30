using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/CharacterEventSO")]
public class CharacterEvent : ScriptableObject
{
    public UnityAction<Character> OnEventRaised;//当事件被调用
    
    public void RaiseEvent(Character character)
    {
        OnEventRaised?.Invoke(character);
    }
    
}
