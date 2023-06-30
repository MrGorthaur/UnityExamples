using UnityEngine;

public class SlotsData : MonoBehaviour, ISlotSpritesData
{
    [Header("Массив спрайтов для инициализации в слоты и поле для дефолтного спрайта")]
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Sprite _deffaultSprite;
    [Header("Максимальное время для текущего уровня")]
    [SerializeField] private float _maxTimebarValue;
    [Header("Время перед тем как закроются слоты")]
    [SerializeField] private float _timeForRemamber;

    public float TimeForRemamber => _timeForRemamber;
    public float MaxTimebarValue => _maxTimebarValue;
    public Sprite DeffaultSprite => _deffaultSprite;
    public Sprite GetRandomSprite()
    {
        var randomCount = Random.Range(0, _sprites.Length);
        return _sprites[randomCount];
    }


}
