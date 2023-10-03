using UnityEngine;

[CreateAssetMenu(menuName = "技能")] //创建新的游戏技
public class SkillData : ScriptableObject
{
    [Header("技能描述")] 
    public float skillID;
    public string skillName;
    public string skillDescription;

    [Header("技能相关资源")] 
    public Sprite skillIcon;
    public string skillAnimationName;

    [Header("技能数据")] 
    public float skillFrontPoint;
    public float skillBackPoint;
    public int skillDamage;
    public float skillChance;
}