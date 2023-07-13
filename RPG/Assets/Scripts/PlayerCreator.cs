using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator
{



    public Player CreatePlayer(GameObject thisGameObject)
    {
        var spellInitializer = new SpellsInitializer();
        var unitStatusData = Resources.Load<UnitDataSO>("ScriptableObjects/UnitData/Player/PlayerStatus");
        var player = thisGameObject.AddComponent<Player>().GetComponent<Player>();
        player.Init(unitStatusData);
        player.Spells = spellInitializer.GetRandomKit();
        return player;

    }
}

