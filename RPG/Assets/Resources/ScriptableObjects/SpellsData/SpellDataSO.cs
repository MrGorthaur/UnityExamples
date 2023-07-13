using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Spells")]
public class SpellDataSO : ScriptableObject, ISpellDataSO
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage;
    [SerializeField] private float _coolDown;
    [SerializeField] private int _manaCost;

    public string Name => _name;
    public int Damage => _damage;
    public float CoolDown => _coolDown;
    public int ManaCost => _manaCost;

}
