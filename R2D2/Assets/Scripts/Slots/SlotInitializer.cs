using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInitializer : MonoBehaviour
{
    private ISlotSpritesData _spriteData;
    private OpenSlot[] _openSlots;
    private List<string> _listChecker;

    public List<string> ListChecker => _listChecker;
    private void Awake()
    {
        _listChecker = new List<string>();
        _spriteData = GetComponent<ISlotSpritesData>();
        _openSlots = GetComponentsInChildren<OpenSlot>();
        foreach (var slot in _openSlots)
        {
            slot.Init(_spriteData);
        }
    }
    private void Start()
    {
        StartCoroutine(CheckOpenSlotList(2));
    }
    private IEnumerator CheckOpenSlotList(float delay)
    {
        _listChecker.Clear();
        foreach (var slot in _openSlots)
        {
            if (slot.IsOpen == true)
            {
                _listChecker.Add(slot.name);
            }
        }
        Debug.Log("List count" + _listChecker.Count);

        yield return new WaitForSeconds(delay);
        StartCoroutine(CheckOpenSlotList(delay));
    }





}
