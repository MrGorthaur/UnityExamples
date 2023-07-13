using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatusUI : MonoBehaviour
{
    private Unit _unit;
    private HealthBar _healthBar;
    private ManaBar _maanaBar;

    private void Awake()
    {
        _healthBar = GetComponentInChildren<HealthBar>();
        _maanaBar= GetComponentInChildren<ManaBar>();

    }


}

