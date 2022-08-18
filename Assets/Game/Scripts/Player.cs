using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    public float MaxHealth { get; private set; }
    public float MinHealth{ get; private set; }
    public float CurrentHealth { get; private set; }

    private bool isKilled = false;
    private Animator _animator;

    public Player()
    {
        MaxHealth = 100f;
        MinHealth = 0;
        CurrentHealth = MaxHealth;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnReceiveHit(float hitPoints)
    {
        if (hitPoints>0)
        {
            if (hitPoints >= CurrentHealth)
            {
                CurrentHealth = MinHealth;
                Kill();
            }
            else
            {
                CurrentHealth -= hitPoints;
            }
        }        
    }

    public void AddHelth(float health)
    {
        if (health > 0& CurrentHealth!=0)
        {
            if (health >= MaxHealth | (CurrentHealth += health)>= MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth += health;
            }
        }
    }

    public void Kill()
    {
        isKilled = true;
        _animator.SetBool(HashAnimNames.Death, isKilled);
    }
}