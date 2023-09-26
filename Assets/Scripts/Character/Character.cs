using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色种类
/// </summary>
public enum type
    {
        Player,Enermy//可以添加更多种类，不知道有没有用反正写着先
    };
    

public class Character : MonoBehaviour
{
    [Header("角色属性")] 
    [SerializeField] protected string _name;
    [SerializeField] public int _maxHp;
    [SerializeField] public int _currentHp;
    [SerializeField] protected float _attackDamage;
    [SerializeField] protected type _type;
    
    protected virtual void Start()
    {
        _currentHp = _maxHp;
    }
}