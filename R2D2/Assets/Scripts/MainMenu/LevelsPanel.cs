using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    private Button[] _buttons;
    private TMP_Text _text;
    private int _lvlCount;
    private void Start()
    {
        _buttons = GetComponentsInChildren<Button>();
        AddLvlComponentToButtons();
    }
    private void AddLvlComponentToButtons()
    {
        _lvlCount = 1;
        foreach (var button in _buttons)
        {
            var lvl = button.gameObject.AddComponent<Level>();
            _text = button.gameObject.GetComponentInChildren<TMP_Text>();
            if (_text != null)
            {
                _text.text = _lvlCount.ToString();
                lvl.LevelCount = _lvlCount;
                _lvlCount++;
            }
        }
    }

    

}
