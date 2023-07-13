using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Enemy _enemy;
    private Image _image;
    private TMP_Text _text;
    private int _maxHealth;
    private int _currentHealth;
    private float _fillAmount;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TMP_Text>();
    }
    private void Start()
    {
        _enemy = FindObjectOfType<Test>().GetComponent<Test>().Enemy;
        _maxHealth = _enemy.Condition.MaxHealth;
        _currentHealth = _enemy.Condition.CurrentHealth;
        _enemy.Condition.OnHealthChanged += Condition_OnHealthChanged;
        _text.text = $"{_maxHealth}";
    }
    private void Update()
    {
        _fillAmount = (float)_currentHealth / _maxHealth;
    }
    private void OnDisable()
    {
        _enemy.Condition.OnHealthChanged -= Condition_OnHealthChanged;
    }
    private void Condition_OnHealthChanged(int damage)
    {
        _currentHealth -= damage;
        _image.fillAmount = _fillAmount;
        _text.text = $"{_currentHealth} / {_maxHealth}";
    }
}
