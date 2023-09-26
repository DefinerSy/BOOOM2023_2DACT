using QFSW.QC;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [Header("玩家受伤相关组件及变量")]
    private PlayerCharacter PlayerCharacter;
    public bool isHurt = false;
    private void Start()
    {
        PlayerCharacter = GetComponent<PlayerCharacter>();
    }
    
    
    /// <summary>
    /// 玩家受伤
    /// </summary>
    /// <param name="Damage">传入受到的伤害值</param>
    [Command]public void Hurt(int Damage)
    {
        isHurt = true;
        PlayerCharacter._currentHp -= Damage;
    }
}