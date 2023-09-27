using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatBar : MonoBehaviour
{
   public Image hpImage;
/// <summary>
/// 接收hp的变更百分比
/// </summary>
/// <param name="persentage">百分比：Current/Max</param>
   public void OnHealthChange(float persentage)
   {
      hpImage.fillAmount = persentage;
   }
}
