using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private Player _player;
    private Image _image;
    private TMP_Text _text;
    private int _maxMana;
    private int _currentMana;
    private float _fillAmount;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TMP_Text>();
    }
    private void Start()
    {
        _player = FindObjectOfType<Test>().GetComponent<Test>().Player;
        _maxMana = _player.Condition.MaxHealth;
        _currentMana = _player.Condition.CurrentHealth;
        _player.Condition.OnManaChanged += Condition_OnManaChanged;
        _text.text = $"{_maxMana}";
    }
    private void Update()
    {
        _fillAmount = (float)_currentMana / _maxMana;
    }
    private void OnDisable()
    {
        _player.Condition.OnManaChanged -= Condition_OnManaChanged;
    }

    private void Condition_OnManaChanged(int spendMana)
    {
        _currentMana -= spendMana;
        _image.fillAmount = _fillAmount;
        _text.text = $"{_currentMana} / {_maxMana}";
    }
}
