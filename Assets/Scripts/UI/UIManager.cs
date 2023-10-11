using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public float dashCDTime;
   
   [FormerlySerializedAs("playerStatBar")] [Header("UI对象")]
   public PlayerStatbar playerStatbar;
   public PlayerDashbar playerDashbar;
   public List<Image> skilluis;

   [Header("动画")] 
   public Animator resetanim;
   
   
   [Header("事件监听")] 
   public CharacterEvent healthEvent;

   public CharacterEvent characterDashEvent;

   public SkillEvent skillResetEvent;

   public SkillEvent skillUsedEvent;
   private bool isbig;
   private void OnEnable()
   {
      healthEvent.OnEventRaised += OnHealthEvent;
      characterDashEvent.OnDashRaised += OnDashEvent;
      skillResetEvent.OnEventRaised += OnSkillResetEvent;
      skillUsedEvent.OnSkillUse += OnSkillUsedEvent;
   }
   
   private void OnDisable()
   {
      healthEvent.OnEventRaised -= OnHealthEvent;
      characterDashEvent.OnDashRaised -= OnDashEvent;
      skillResetEvent.OnEventRaised -= OnSkillResetEvent;
      skillUsedEvent.OnSkillUse -= OnSkillUsedEvent;
   }

   private void OnDashEvent()
   {
      playerDashbar.OnDashUsed(dashCDTime);

      //Debug.Log(playerDashbar.dashImage.fillAmount);
   }

   private void OnSkillResetEvent(List<SkillData> skillList)
   {
      resetanim.Play("SkillReset1");
      for (int i = 0; i < skilluis.Count; i++)
      {
         skilluis[i].gameObject.GetComponent<Button>().interactable = true;
         skilluis[i].sprite = skillList[i].skillIcon;
      }
   }

   private void OnHealthEvent(Character character,int Damage)
   {
      float persentage = character._currentHp / character._maxHp;
      playerStatbar.OnHealthChange(persentage,Damage);
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
         resetanim.Play("OnSkill1");
         isbig = true;
      }
      else if(Input.GetKeyUp(KeyCode.Semicolon))
      {
         resetanim.Play("OutSkill1");
         isbig = false;
      }
   }
}
