using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaskInitializer : MonoBehaviour
{
    private LevelDataHolder _holder;
    private ISlotSpritesData _spritesData;
    private SlotInitializer _slotInitializer;
    private Task[] _tasks;
    private List<string> _taskNames;
    private List<string> _activeSlotNames;
    private int _difficult = 2;
    private bool _isMatch = true;

    public bool IsMatch => _isMatch;
    private void Awake()
    {
        //_holder = FindAnyObjectByType(typeof(LevelDataHolder)).GetComponent<LevelDataHolder>();
        _slotInitializer = FindObjectOfType<SlotInitializer>().GetComponent<SlotInitializer>();
        _spritesData = FindObjectOfType<SlotsData>().GetComponent<ISlotSpritesData>();
        _taskNames = new List<string>();
        _activeSlotNames = new List<string>(_slotInitializer.ListChecker);
        _tasks = GetComponentsInChildren<Task>();
        //_difficult = _holder.Difficult;

    }
    private void Start()
    {
        SetActiveTask(_difficult);
        AddToTaskList();
     
    }
    private void FixedUpdate()
    {
        CheckInGameplay();
    }
    private void SetActiveTask(int difficult)
    {
        for (int i = 0; i < difficult; i++)
        {
            _tasks[i].gameObject.SetActive(true);
        }
    }
    private void AddToTaskList()
    {
        foreach (var task in _tasks)
        {
            if (task.gameObject.activeInHierarchy)
            {
                for (int i = 1; i < task.Count; i++)
                {
                    _taskNames.Add(task.name);
                }
            }
        }
    }
    private void CheckInGameplay()
    {
        foreach (var slotName in _activeSlotNames)
        {
            if (!_taskNames.Contains(slotName))
            {
                _isMatch = false;
            }
        }
        
    }

    




}
