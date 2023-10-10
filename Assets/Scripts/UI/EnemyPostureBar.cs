using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class EnemyPostureBar : MonoBehaviour
{
    public Image postureImage;

    public float postureMax;
    public float postureCurrent;
    public bool isHurt;//每受到一次普通攻击就把该值设为true
    public float postureDamage;//测试用

    public float timeToRecover;//受伤多久后恢复架势条
    public float recoverSpeed;//恢复速度
    private float timer;//计时器
    
    
    [Header("受伤时架势条震动有关参数")] 
    public float time = 0f;
    public int power = 0;
    public int times = 0;
    public int angle = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        postureCurrent = postureMax;
        postureImage.fillAmount = 1;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHurt)
        {
            PostureReduce(postureDamage);
            //Debug.Log("开始计时");
            timer = 0;
            isHurt = false;
        }
        if (!isHurt)
        {
            timer += Time.deltaTime;
        }
        if (timer >= timeToRecover)
        {
            PostureRecover();
        }
    }

    public void PostureReduce(float damage)
    {
        postureCurrent -= damage;
        if (postureCurrent <= 0)
        {
            postureCurrent = 0;
        }
        postureImage.fillAmount = postureCurrent / postureMax;
        gameObject.transform.DOShakePosition(time, power, times, angle);
    }

    public void PostureRecover()
    {
        postureCurrent += Time.deltaTime * recoverSpeed;
        if (postureCurrent >= postureMax)
        {
            postureCurrent = postureMax;
        }
        postureImage.fillAmount = postureCurrent / postureMax;
    }
}
