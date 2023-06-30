using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    private Image _image;
    private Sprite _spriteImage;
    private int _count;
    private TMP_Text _textCount;

    public int Count => _count;
    public void Init(ISlotSpritesData slotSprites)
    {
        _spriteImage = slotSprites.GetRandomSprite();
    }
  
    private void Start()
    {
        _image = GetComponent<Image>(); 
        _textCount = GetComponentInChildren<TMP_Text>();
        _image.sprite = _spriteImage;   
        gameObject.name = _spriteImage.name;
        _count = RandomSlotsCounter();
        _textCount.text = _count.ToString();
        this.gameObject.SetActive(false);
    }

    private int RandomSlotsCounter()
    {
        var r = Random.Range(3, 5);
        return r;
    }


}
