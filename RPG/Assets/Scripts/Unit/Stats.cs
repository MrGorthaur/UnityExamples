using System;
using System.Collections.Generic;


public class Stats
{
    public int Strength {get;private set;}
    public int Dextricity {get;private set;}
    public int Intelligence { get;private set;}

    public Stats(int strength, int dextricity, int intelligence)
    {
        Strength = strength;
        Dextricity = dextricity;
        Intelligence = intelligence;
    }
    public Stats(IStatsData statsData)
    {
        Strength = statsData.Strength;
        Dextricity = statsData.Dextricity;
        Intelligence = statsData.Intelligence;
    }
}

