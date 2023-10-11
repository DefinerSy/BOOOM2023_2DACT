using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 角色种类
/// </summary>
public enum type
{
    Player,
    Enermy //可以添加更多种类，不知道有没有用反正写着先
};


public class Character : MonoBehaviour
{
    [Header("角色属性")] [SerializeField] protected string _name;
    [SerializeField] public float _maxHp;
    [SerializeField] public float _currentHp;
    [SerializeField] public int _attackDamage;
    [SerializeField] protected type _type;
    [Header("角色事件")]
    [SerializeField] 
    public UnityEvent<Character,int> OnHealthChange;
    bool isDie = false;

    protected virtual void Start()
    {
        _currentHp = _maxHp;
        HealthIsChange(0);
    }

    protected virtual void Update()
    {
        CharacterDie();
    }

    protected virtual void CharacterDie()
    {
        if (_currentHp <= 0 && !isDie)
        {
            Debug.Log(_name + "Die");
            isDie = true;
        }
        else if(_currentHp>0 && isDie)
        {
            isDie = false;
        }
    }
    public void HealthIsChange(int Damage)
    {
        Debug.Log("HP:"+_currentHp+"->"+(_currentHp-Damage));
        _currentHp -= Damage;
        OnHealthChange?.Invoke(this,Damage);
        
    }
}