using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "技能")] //创建新的游戏技
public class SkillData : ScriptableObject
{
    [Header("技能描述")] 
    public float skillID;
    public string skillName;
    [TextArea(3, 10)]
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
[CustomEditor(typeof(SkillData))]
public class SkillDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SkillData skillData = (SkillData) target;
        EditorGUILayout.LabelField("技能数据："+skillData.skillName.ToUpper(), 
            EditorStyles.boldLabel);
        EditorGUILayout.Space(10);
        base.OnInspectorGUI();
    }
}