using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public Image hpImage;
    public Image hpDelayImage;
    public float hpMax;
    public float hpCurrent;
    public float hpRefuseSpeed=1f;

    public bool isHurtHP;

    public float HPDamge;
    
    [Header("受伤时血条震动有关参数")] 
    public float time = 0f;
    public int power = 0;
    public int times = 0;
    public int angle = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        hpCurrent = hpMax;
        hpDelayImage.fillAmount = 1;
        hpImage.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurtHP)
        {
            GetHurt(HPDamge);
            isHurtHP = false;
        }
        if (hpDelayImage.fillAmount > hpImage.fillAmount)
        {
            hpDelayImage.fillAmount -= Time.deltaTime * hpRefuseSpeed;
        }
        else
        {
            hpDelayImage.fillAmount = hpImage.fillAmount;
        }
        
    }

    public void GetHurt(float damage)
    {
        hpCurrent -= damage;
        hpImage.fillAmount = hpCurrent / hpMax;
        gameObject.transform.DOShakePosition(time, power, times, angle);
    }
}
