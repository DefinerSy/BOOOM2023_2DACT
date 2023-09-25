using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [Header("技能资源")]
    public List<SkillData> allSkills;
    public List<Image> skillUi;

    public Sprite GetSkill()
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
            Sprite skillImage = posibleList[Random.Range(0, posibleList.Count)].skillIcon;
            return skillImage;
        }
        return null;
    }

    public void ResetSkillIcon()
    {
        foreach (var image in skillUi)
        {
            image.sprite = GetSkill();
        }
    }
}