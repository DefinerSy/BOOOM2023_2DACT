using DG.Tweening;
using QFSW.QC;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [Header("玩家受伤相关组件及变量")]
    private PlayerCharacter PlayerCharacter;

    private Animator anim;
    public bool isHurt = false;

    [Header("受伤时血条震动有关参数")] 
    public GameObject hpBar;
    public float time = 0f;
    public int power = 0;
    public int times = 0;
    public int angle = 0;
    
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
        PlayerCharacter.HealthIsChange(Damage);
        if (Damage > 0)
        {
            anim.SetTrigger("Hurt");
            hpBar.transform.DOShakePosition(time, power, times, angle);
        }
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