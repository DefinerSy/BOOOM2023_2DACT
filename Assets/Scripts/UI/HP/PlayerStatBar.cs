using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
   public Image hpImage;
   public Image hpDelayImage;
   public float hpRefuseSpeed=1f;

   [Header("受伤时血条震动有关参数")] 
   public float time = 0f;
   public int power = 0;
   public int times = 0;
   public int angle = 0;
   private void Start()
   {
      hpDelayImage.fillAmount = 1;
   }

   private void Update()
   {
      if (hpDelayImage.fillAmount > hpImage.fillAmount)
      {
         hpDelayImage.fillAmount -= Time.deltaTime * hpRefuseSpeed;
      }
      else
      {
         hpDelayImage.fillAmount = hpImage.fillAmount;
      }
   }

   /// <summary>
/// 接收hp的变更百分比
/// </summary>
/// <param name="persentage">百分比：Current/Max</param>
/// <param name="Damage">伤害值</param>
   public void OnHealthChange(float persentage,int Damage)
   {
      hpImage.fillAmount = persentage;
      if (Damage>0)
      {
         gameObject.transform.DOShakePosition(time, power, times, angle);
      }
   }
}
