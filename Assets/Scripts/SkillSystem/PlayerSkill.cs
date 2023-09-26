﻿using System.Collections.Generic;
using QFSW.QC;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerSkill : MonoBehaviour
{
    [Header("技能资源")]
    public List<SkillData> allSkills;
    public List<Image> skillUi;
    public int skillNumber = 4;
    
    /// <summary>
    /// 随机获取技能
    /// </summary>
    /// <returns>skillData列表,可以通过SkillData.skillIcon获取图像</returns>
    public List<SkillData> GetSkill()
    {
        List<SkillData> finalList = new List<SkillData>();
        for (int i = 0; i < skillNumber; i++)
        {
            int RangeNumber = Random.Range(1, 101);//1~100
            List<SkillData> posibleList = new List<SkillData>();
            
            foreach (SkillData skill in allSkills)
            {
                if (skill.skillChance >=RangeNumber)
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
        List<SkillData> skillList = GetSkill();
        for (int i = 0; i < skillUi.Count; i++)//todo:这个方法可以UI参考,UI写完后这里记得和变量一起删掉
        {
            skillUi[i].sprite = skillList[i].skillIcon;
        }
    }

    private void Start()
    {
        skillNumber = skillUi.Count;
        ResetSkillIcon();
    }
}