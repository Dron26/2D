using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]


public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private Animator _animator;
    private int _selectpoint;
    private float _minDistance;
    private float _speed;
    private float _waitTime;
    private float _startWaitTime;
    private bool _isWalk;
    private bool _flip;
    private bool _isFacingRight = true;
    private SpriteRenderer _spriteRenderer;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _selectpoint = Random.Range(0, _points.Length);
        _isWalk = true;
        _startWaitTime = 1;
        _speed = 15;
        _minDistance = 0.2f;
        _waitTime = _startWaitTime;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[_selectpoint].position, _speed * Time.deltaTime);
        _animator.SetBool(HashAnimNames.SkeletonWalk, _isWalk);

        if (Vector2.Distance(transform.position,_points[_selectpoint].position)< _minDistance)
        {
            _isWalk = false;

            if (_waitTime<=0)
            {
                StartCoroutine(WaitInPoint());
                _waitTime = _startWaitTime;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
            
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _flip = !_flip;
        _spriteRenderer.flipX = _flip;
    }

    private IEnumerator WaitInPoint()
    {
        _selectpoint = Random.Range(0, _points.Length);       
        Flip();
        _isWalk = true;
        yield return new WaitForSeconds(0.1f);
    }
}
