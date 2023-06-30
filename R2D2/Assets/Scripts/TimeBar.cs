using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimeBar : MonoBehaviour
{
    private Image _imgBar;
    private float _maxTime;
    private float _currentTime;
    private SlotsData _data;

    public bool IsNoTime => _currentTime >= _maxTime;
    private void Start()
    {
        _imgBar = GetComponent<Image>();
        _data = FindObjectOfType<SlotsData>().GetComponent<SlotsData>();
        _maxTime = _data.MaxTimebarValue;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime / _maxTime;
        _imgBar.fillAmount = _currentTime;
    }

}
