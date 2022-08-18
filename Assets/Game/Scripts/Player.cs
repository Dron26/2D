using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    public event UnityAction<float> HealthHandler;

    public float MaxHealth { get; private set; }
    public float MinHealth { get; private set; }
    public float CurrentHealth { get; private set; }

    private bool isKilled = false;
    private Animator _animator;

    public Player()
    {
        MaxHealth = 100;
        MinHealth = 0;
        CurrentHealth = MaxHealth;
    }

    public void OnReceiveHit(float hitPoints)
    {
        hitPoints = Mathf.Clamp(hitPoints, MinHealth, MaxHealth);

        CurrentHealth -= hitPoints;
        CurrentHealth = Mathf.Clamp(CurrentHealth, MinHealth, MaxHealth);

        if (CurrentHealth == MinHealth)
        {
            Kill();
        }

        HealthHandler?.Invoke(CurrentHealth);
    }

    public void AddHelth(float health)
    {
        if (health !=0)
        {
            health = Mathf.Clamp(health, MinHealth, MaxHealth);

            CurrentHealth += health;
            CurrentHealth = Mathf.Clamp(CurrentHealth, MinHealth, MaxHealth);

            HealthHandler?.Invoke(CurrentHealth);
        }        
    }

    public void Kill()
    {
        isKilled = true;
        _animator.SetBool(HashAnimNames.Death, isKilled);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}