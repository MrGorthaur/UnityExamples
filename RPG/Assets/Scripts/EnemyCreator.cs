using System.Collections;
using UnityEngine;


public class EnemyCreator 
{
    private IUnitDataSO[] _unitData;
    private SpellsInitializer _spellsInitializer;

    public EnemyCreator()
    {
        _unitData = Resources.LoadAll<UnitDataSO>("ScriptableObjects/UnitData");
        _spellsInitializer = new SpellsInitializer();   
    }

    public Enemy CreateEnemy(GameObject thisGameObject)
    {
        var r = Random.Range(0, _unitData.Length);
        var unitStatusData = _unitData[r];
        var enemy = thisGameObject.AddComponent<Enemy>().GetComponent<Enemy>();
        enemy.Init(unitStatusData);
        enemy.Spells = _spellsInitializer.GetRandomKit();
        return enemy;
    }


}
