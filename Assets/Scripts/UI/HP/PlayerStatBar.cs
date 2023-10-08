using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
   public Image hpImage;
   public Image hpDelayImage;
   public float hpRefuseSpeed=1f;

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
   public void OnHealthChange(float persentage)
   {
      hpImage.fillAmount = persentage;
   }
}
