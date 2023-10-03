using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
   [Header("UI对象")]
   public PlayerStatBar playerStatBar;

   public List<Image> skilluis;
   
   
   [Header("事件监听")] 
   public CharacterEvent healthEvent;

   public SkillEvent skillResetEvent;

   private void OnEnable()
   {
      healthEvent.OnEventRaised += OnHealthEvent;
      skillResetEvent.OnEventRaised += OnSkillResetEvent;
   }

   private void OnDisable()
   {
      healthEvent.OnEventRaised -= OnHealthEvent;
      skillResetEvent.OnEventRaised -= OnSkillResetEvent;
   }

   private void OnSkillResetEvent(List<SkillData> skillList)
   {
      for (int i = 0; i < skilluis.Count; i++)
      {
         skilluis[i].sprite = skillList[i].skillIcon;
      }
   }

   private void OnHealthEvent(Character character)
   {
      float persentage = character._currentHp / character._maxHp;
      playerStatBar.OnHealthChange(persentage);
   }
   
   
}
