using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;

    private void Awake()
    {
        _slider=GetComponent<Slider>();
    }

    private void Start()
    {
        SetMaxHealth(_player.MaxHealth);
    }

    private void Update()
    {
        if (_player.CurrentHealth!=_slider.value)
        {
            SetHealth(_player.CurrentHealth);
        }
            
              
    }

    private void SetMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    private void SetHealth(float health)
    {
        int _speedChangeSlider = 20;
        _slider.value = Mathf.MoveTowards(_slider.value, health, Time.deltaTime* _speedChangeSlider);
    }
}
