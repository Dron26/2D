using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _corountine;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _player.HealthHandler += ChangeHealt;
    }

    private void Start()
    {
        SetSliderParameters(_player.MaxHealth);
    }

    public IEnumerator SetSliderValue(float health)
    {
        int step = 10;

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, Time.deltaTime * step);

            yield return null;
        }
    }

    private void OnDisable()
    {
        _player.HealthHandler -= ChangeHealt;
    }

    public void ChangeHealt(float health)
    {
        if (_corountine != null) 
        {
            StopCoroutine(_corountine); 
        }

        _corountine = StartCoroutine(SetSliderValue(health));
    }

    private void SetSliderParameters(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }
}
