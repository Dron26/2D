using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Slider _slider;
    private Coroutine _corountine;
    private bool _isCorountineWorkEnd;
    private float _tempHealth;
    private bool isHealthWasChange;

    public void ChangeHealt(float health)
    {
        if (_corountine == null | _isCorountineWorkEnd == true)
        {
            _corountine = StartCoroutine(SetSliderValue(health));
        }
        else
        {
            isHealthWasChange = true;
            _tempHealth = health;
        }

    }

    public IEnumerator SetSliderValue(float health)
    {
        int step = 10;

        _isCorountineWorkEnd = false;

        while (_slider.value != health)
        {
            if (isHealthWasChange)
            {
                health = _tempHealth;
                isHealthWasChange = false;
            }
            _slider.value = Mathf.MoveTowards(_slider.value, health, Time.deltaTime * step);

            yield return null;
        }

        _tempHealth = 0;
        _isCorountineWorkEnd = true;
    }


    private void OnEnable()
    {
        _player.HealthHandler += ChangeHealt;
    }

    private void OnDisable()
    {
        _player.HealthHandler -= ChangeHealt;
    }

    private void Awake()
    {
        isHealthWasChange = false;
        _isCorountineWorkEnd = false;
        _slider =GetComponent<Slider>();
    }

    private void Start()
    {
        SetMaxHealth(_player.MaxHealth);
    }

    private void SetMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }
}
