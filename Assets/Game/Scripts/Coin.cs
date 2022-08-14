using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HashAnimNames))]

public class Coin : MonoBehaviour
{
    private Animator _animator;
    private bool _isRotate;

    private void Awake()
    {
         _isRotate=true;
        _animator = GetComponent<Animator>();
        _animator.SetBool(HashAnimNames.CoinRotation, _isRotate);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isRotate = false;
            _animator.SetBool(HashAnimNames.CoinRotation, _isRotate);
            Destroy(gameObject, 1.0f);
        }
    }
}
