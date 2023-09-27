using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Event/CharacterEventSO")]
public class CharacterEventSO : ScriptableObject
{
    public UnityAction<PlayerHP> OnEventRaised;

    public void RaiseEvent(PlayerHP hp)
    {
        OnEventRaised?.Invoke(hp);
    }
}
