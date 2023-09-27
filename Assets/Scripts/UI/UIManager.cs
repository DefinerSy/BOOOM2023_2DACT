using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public PlayerStatBar playerStatBar;
   
   [Header("事件监听")] 
   public CharacterEventSO healthEvent;

   private void OnEnable()
   {
      healthEvent.OnEventRaised += OnHealthEvent;
   }

   private void OnDisable()
   {
      healthEvent.OnEventRaised += OnHealthEvent;
   }

   private void OnHealthEvent(PlayerHP hp)
   {
      var persentage = hp.hpcurrent / hp.hpmax;
      playerStatBar.OnHealthChange(persentage);
   }
}
