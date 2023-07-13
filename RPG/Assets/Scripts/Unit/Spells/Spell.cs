using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spell
{
    private float _coolDown;
    private int _damage;
    private bool _isReady = true;
    public string Name { get; private set; }
    public int ManaCost { get; private set; }
    public bool IsReady => _isReady;

    public Spell(ISpellDataSO spellData)
    {
        _damage = spellData.Damage;
        _coolDown = spellData.CoolDown;
        Name = spellData.Name;
        ManaCost = spellData.ManaCost;

    }
    public async void CastSpell(Unit unit)
    {
        if (_isReady == true)
        {
            unit.TakeDamage(_damage);
            _isReady = false;
        }
        await StartCooldown();

    }
    private async Task StartCooldown()
    {
        await Task.Delay((int)(_coolDown * 1000));
        _isReady = true;
        Debug.Log($"_isReady: {_isReady}");
    }
    public override string ToString()
    {
        return $"Name: {Name} " +
               $"Damage: {_damage}" +
               $"CoolDown: {_coolDown}" +
               $"Ready: {IsReady}";
    }

}
