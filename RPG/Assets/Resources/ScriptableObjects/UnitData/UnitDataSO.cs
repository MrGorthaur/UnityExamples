using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitStatus")]
public class UnitDataSO : ScriptableObject, IUnitDataSO
{
    [Header("Condition")]
    [SerializeField] private int _health;
    [SerializeField] private int _mana;
    [Header("Level")]
    [SerializeField] private int _level;
    [Space(10)]
    [Header("Stats")]
    [SerializeField] private int _strenght;
    [SerializeField] private int _dextricity;
    [SerializeField] private int _intelligence;

    public int Health => _health;
    public int Mana => _mana;
    public int Level => _level;
    public int Strength => _strenght;
    public int Dextricity => _dextricity;
    public int Intelligence => _intelligence;

    private int HealthModifire() => _health + _strenght * _level;
    private int ManaModifire() => _mana + _intelligence * _level;




    public void PrintStatus() => Debug.Log(
        $"Health:  {_health}, " +
        $"Mana:  {_mana}, " +
        $"Level:  {_level}, " +
        $"Stats:{_strenght},{_dextricity}.{_intelligence}"
        );
}
