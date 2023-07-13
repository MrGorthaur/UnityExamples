using System;
using System.Collections.Generic;

public class Level
{
    private int _maxExperience = 200;

    public int CurrentLvl { get; private set; }
    public int CurrentExp { get; private set; }

    public Level(ILevelDataSo levelData) 
    {
        CurrentLvl = levelData.Level;
    }

    public void GetExp(int exp)
    {
        CurrentExp += exp;
        if(CurrentExp >= _maxExperience)
        {
            CurrentLvl += 1;
            _maxExperience += CurrentLvl * _maxExperience;
        }
    }
  


}

