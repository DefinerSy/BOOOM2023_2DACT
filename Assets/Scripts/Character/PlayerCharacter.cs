using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : Character
{
    [SerializeField] private Slider Hpbar;
    [SerializeField] private Text HpText;

    protected override void Start()
    {
        base.Start();
        Hpbar.maxValue = _maxHp;
    }

    protected override void Update()
    {
        base.Update();
        Hpbar.value = _currentHp;
        HpText.text = (Hpbar.value/100).ToString("P0");
    }
}
