using QFSW.QC;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [Header("玩家受伤相关组件及变量")]
    private PlayerCharacter PlayerCharacter;

    private Animator anim;
    public bool isHurt = false;
    
    private void Start()
    {
        PlayerCharacter = this?.GetComponent<PlayerCharacter>();
        anim = GetComponent<Animator>();
    }
    
    
    /// <summary>
    /// 玩家受伤
    /// </summary>
    /// <param name="Damage">传入受到的伤害值</param>
    [Command]public void Hurt(int Damage)
    {
        isHurt = true;
        PlayerCharacter._currentHp -= Damage;
        anim.SetTrigger("Hurt");
        if (PlayerCharacter._currentHp <=0)
        {
            Die();
        }
    }

    [Command]
    public void Die()
    {
        anim.SetTrigger("Death");
    }
}