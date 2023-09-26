using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyCharacter : Character
{
    [Header("架势条")]
    [SerializeField] float _maxPosture;
    [SerializeField] float _currentPosture;

    protected override void Start()
    {
        base.Start();
        _currentPosture = _maxPosture;
    }
}
