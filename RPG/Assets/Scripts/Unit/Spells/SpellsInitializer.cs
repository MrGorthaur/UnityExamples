using System.Collections.Generic;
using UnityEngine;

public class SpellsInitializer
{
    private ISpellDataSO[] _spellsData;
    public SpellsInitializer() 
    {
        _spellsData = Resources.LoadAll<SpellDataSO>("ScriptableObjects/SpellsData");
    }

    public Spell[] GetRandomKit() 
    {
        Spell[] kit = new Spell[4];
        int r = Random.Range(1,_spellsData.Length);
        for(int i = 0; i < kit.Length ; i++) 
        {
            kit[i] = new Spell(_spellsData[i]);
        }
        return kit;
    }
    public Spell GetSpell()
    {
        var spellData = Resources.Load<SpellDataSO>("ScriptableObjects/SpellsData/FireBall");
        var spell = new Spell(spellData);
        return spell;
    }

}

