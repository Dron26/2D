using UnityEngine;

[RequireComponent(typeof(HashAnimNames))]

public class Coin : MonoBehaviour
{
    private HashAnimNames _animation;
    private Animator _animator;
    private bool isRotate;

    private void Awake()
    {
         isRotate=true;
        _animation = GetComponent<HashAnimNames>();
        _animator = GetComponent<Animator>();
        _animator.SetBool(_animation.CoinRotation, isRotate);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            isRotate = false;
            _animator.SetBool(_animation.CoinRotation, isRotate);
            Destroy(gameObject, 1.0f);
        }
    }
}
