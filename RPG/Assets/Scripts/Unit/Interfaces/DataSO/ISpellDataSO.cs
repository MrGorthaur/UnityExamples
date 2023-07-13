using System;
using System.Collections.Generic;



public interface ISpellDataSO
{
    public string Name { get; }
    public int Damage { get; }
    public float CoolDown { get; }
    public int ManaCost { get; }
}

