using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitAnimator))]
public abstract class Unit : MonoBehaviour
{

    private Stats _stats;
    private UnitAnimator _animator;

    public Condition Condition { get; private set; }
    public Level Level { get; private set; }
    public Spell[] Spells { get; set; }

    public void Init(IUnitDataSO unitData)
    {
        Condition = new Condition(unitData);
        Level = new Level(unitData);
        _stats = new Stats(unitData);
        Spells = new Spell[4];
    }

    private void Awake()
    {
        _animator = GetComponent<UnitAnimator>();
    }

    public void Print()
    {
        Debug.Log(Condition.CurrentHealth + "  " + Condition.CurrentMana);
        Debug.Log(Spells[0]);
    }
    public void TakeDamage(int damage)
    {
        Condition.TakeDamage(damage);
        _animator.TakeDamageAnimation();
    }
    public void CastSpell(Unit unit, int numberOfSpell)
    {
        var spell = Spells[numberOfSpell];
        if (Condition.CurrentMana >= spell.ManaCost)
        {
            Condition.SpendMana(spell);
            spell.CastSpell(unit);
            Debug.Log(spell);
        }
    }
    public void Die()
    {
        if (Condition.IsAlive == false)
        {
            _animator.DieAnimation();
        }
    }







}
