using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHolder : MonoBehaviour 
{
    private int _level;
    private int _difficult;

    public int Level => _level;
    public int Difficult => _difficult;
    public void Init(Level level)
    {
        _level = level.LevelCount;
        _difficult = level.LevelDifficult;
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}

