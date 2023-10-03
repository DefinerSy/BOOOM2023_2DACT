using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
   [Header("UI对象")]
   public PlayerStatBar playerStatBar;

   public List<Image> skilluis;

   [Header("动画")] 
   public Animator resetanim;
   
   
   [Header("事件监听")] 
   public CharacterEvent healthEvent;

   public SkillEvent skillResetEvent;

   public SkillEvent skillUsedEvent;
   private bool isbig;
   private void OnEnable()
   {
      healthEvent.OnEventRaised += OnHealthEvent;
      skillResetEvent.OnEventRaised += OnSkillResetEvent;
      skillUsedEvent.OnSkillUse += OnSkillUsedEvent;
   }



   private void OnDisable()
   {
      healthEvent.OnEventRaised -= OnHealthEvent;
      skillResetEvent.OnEventRaised -= OnSkillResetEvent;
      skillUsedEvent.OnSkillUse -= OnSkillUsedEvent;
   }

   private void OnSkillResetEvent(List<SkillData> skillList)
   {
      resetanim.Play("SkillReset");
      for (int i = 0; i < skilluis.Count; i++)
      {
         skilluis[i].gameObject.GetComponent<Button>().interactable = true;
         skilluis[i].sprite = skillList[i].skillIcon;
      }
   }

   private void OnHealthEvent(Character character)
   {
      float persentage = character._currentHp / character._maxHp;
      playerStatBar.OnHealthChange(persentage);
   }
   
   private void OnSkillUsedEvent(int usedskill)
   {
      skilluis[usedskill].gameObject.GetComponent<Button>().interactable = false;
      //todo:后面换动画
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.Semicolon) && !isbig)
      {
         resetanim.Play("OnSkill");
         isbig = true;
      }
      else if(Input.GetKeyUp(KeyCode.Semicolon))
      {
         resetanim.Play("OutSkill");
         isbig = false;
      }
   }
}
