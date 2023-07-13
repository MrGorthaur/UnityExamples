using System;
using System.Collections.Generic;
using UnityEngine;


public class Condition
{
    private int _health;
    private int _mana;
    
    public event Action<int> OnHealthChanged;
    public event Action<int> OnManaChanged;

    public bool IsAlive { get; private set; }
    public int CurrentHealth { get; private set; }
    public int CurrentMana { get; private set; }
    public int MaxHealth => _health;
    public int MaxMana => _mana;
    public Condition(IConditionDataSO statusData)
    {
        _health = statusData.Health;
        _mana = statusData.Mana;
        CurrentHealth = _health;
        CurrentMana = _mana;
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            IsAlive = false;
        }
        OnHealthChanged?.Invoke(damage); 
    }
    public void SpendMana(Spell spell)
    {
        CurrentMana -= spell.ManaCost;
        OnManaChanged?.Invoke(spell.ManaCost);
    }



}
