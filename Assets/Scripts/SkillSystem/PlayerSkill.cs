using System;
using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum skillstate
{
    Ready,
    Using,
    Cooldown
}

public class PlayerSkill : MonoBehaviour
{
    [Header("技能资源")] 
    public List<SkillData> allSkills;


    [Header("预备技能")] public List<SkillData> skillList;
    public int skillNumber = 4;
    
    [Header("技能重置事件")]
    public UnityEvent<List<SkillData>> OnSkillReady;
    [Header("技能释放事件")]
    public UnityEvent<int> OnSkillUsed;
    
    /// <summary>
    /// 随机获取技能
    /// </summary>
    /// <returns>skillData列表,可以通过SkillData.skillIcon获取图像</returns>
    public List<SkillData> GetSkill()
    {
        List<SkillData> finalList = new List<SkillData>();
        for (int i = 0; i < skillNumber; i++)
        {
            int RangeNumber = Random.Range(1, 101); //1~100
            List<SkillData> posibleList = new List<SkillData>();

            foreach (SkillData skill in allSkills)
            {
                if (skill.skillChance >= RangeNumber)
                {
                    posibleList.Add(skill);
                }
            }

            if (posibleList.Count > 0)
            {
                SkillData skillImage = posibleList[Random.Range(0, posibleList.Count)];
                finalList.Add(skillImage);
            }
        }

        return finalList;
    }

    /// <summary>
    /// 将技能同步到图标（UI可以参考这个）
    /// </summary>
    [Command]
    public void ResetSkillIcon()
    {
        skillList = GetSkill();
        OnSkillReady?.Invoke(skillList);
        
    }

    private void Start()
    {
        ResetSkillIcon();
    }

    /// <summary>
    /// 技能使用
    /// </summary>
    void skillUsage()
    {
        if (skillList.Count > 0)
        {
            if(Input.GetKey(KeyCode.Semicolon))
            {
                //传递按下特殊键
                if (Input.GetKeyDown(KeyCode.J) && skillList[0] != null)
                {
                    OnSkillUsed?.Invoke(0);
                    Debug.Log(skillList[0].skillName + " is Used");
                    //skillList[0].skillAnimationName = "Attack1";
                }

                if (Input.GetKeyDown(KeyCode.I) && skillList[1] != null)
                {
                    OnSkillUsed?.Invoke(1);
                    Debug.Log(skillList[1].skillName + " is Used");
                    //skillList[1].skillAnimationName = "Attack2";
                }

                if (Input.GetKeyDown(KeyCode.L) && skillList[2] != null)
                {
                    OnSkillUsed?.Invoke(2);
                    Debug.Log(skillList[2].skillName + " is Used");
                    //skillList[2].skillAnimationName = "Attack3";
                }

                if (Input.GetKeyDown(KeyCode.K) && skillList[3] != null)
                {
                    OnSkillUsed?.Invoke(3);
                    Debug.Log(skillList[3].skillName + " is Used");
                    //skillList[3].skillAnimationName = "Attack4";
                }
            }
        }
    }

    private void Update()
    {
        skillUsage();
    }
}