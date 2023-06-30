using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class OpenSlot : MonoBehaviour
{
    private Image _img;
    private Sprite _imageSprite;
    private InteractiveSlot _deffaultSlot;
    private bool _isOpen = false;

    public bool IsOpen => _isOpen;
    public void Init(ISlotSpritesData spriteData)
    {
        _imageSprite = spriteData.GetRandomSprite();
        _deffaultSlot = GetComponentInChildren<InteractiveSlot>();
        _deffaultSlot.Init(spriteData);
    }
    private void Start()
    {
        _img = GetComponent<Image>();
        _img.sprite = _imageSprite;
        gameObject.name = _imageSprite.name;
    }
    private void FixedUpdate()
    {
        CheckSlotIsOpen();
    }
    public void CheckSlotIsOpen()
    {
        if (_deffaultSlot.gameObject.activeInHierarchy == false)
        {
            _isOpen = true;
        }
    }



}
