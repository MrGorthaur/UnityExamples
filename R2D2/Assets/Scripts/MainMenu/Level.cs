using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum Difficult
{
    Training = 1,
    Easy = 2,
    Normal = 3,
    Hard= 4,
}
public class Level : MonoBehaviour, IPointerClickHandler
{
    private bool _isOpen;
    private int _count;
    private Button _button;
    private Difficult _difficult;

    public int LevelDifficult => (int)_difficult;
    public bool IsOpen { get => _isOpen; set { _isOpen = value; } }
    public int LevelCount { get => _count; set { _count = value; } }
    private void Start()
    {
        _button = GetComponent<Button>();
        SetDifficult();
        Debug.Log(_count + "   " + _difficult);
    }

    private void SetDifficult()
    {
        if (_count < 5)
        {
            _difficult = Difficult.Training;
        }
        else if (_count > 5 && _count < 10)
        {
            _difficult = Difficult.Easy;
        }
        else if (_count > 10 && _count < 15)
        {
            _difficult = Difficult.Normal;
        }
        else if (_count > 15)
        {
            _difficult = Difficult.Hard;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var obj = new GameObject("LevelDataHolder");
        var holder = obj.AddComponent<LevelDataHolder>().GetComponent<LevelDataHolder>();
        holder.Init(this);
    }
}
