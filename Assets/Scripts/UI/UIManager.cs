using UnityEngine;

public class UIManager : MonoBehaviour
{
   [Header("UI对象")]
   public PlayerStatBar playerStatBar;
   
   [Header("事件监听")] 
   public CharacterEvent healthEvent;

   private void OnEnable()
   {
      healthEvent.OnEventRaised += OnHealthEvent;
   }

   private void OnDisable()
   {
      healthEvent.OnEventRaised -= OnHealthEvent;
   }

   private void OnHealthEvent(Character character)
   {
      float persentage = character._currentHp / character._maxHp;
      playerStatBar.OnHealthChange(persentage);
   }
}
