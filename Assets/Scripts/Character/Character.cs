using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] public int _maxHp;
    [SerializeField] public int _currentHp;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected type _type;
    bool isDie = false;

    protected virtual void Start()
    {
        _currentHp = _maxHp;
    }

    protected virtual void Update()
    {
        CharacterDie();
    }

    protected void CharacterDie()
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
}