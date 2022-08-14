using UnityEngine;

[RequireComponent(typeof(HashAnimNames))]

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private Animator _animator;
    private HashAnimNames _animation;
    private int _selectpoint;
    private float _minDistance;
    private float _speed;
    private float _waitTime;
    private float _startWaitTime;
    private bool _isWalk;
    private bool _flip;
    private bool _isFacingRight = true;


    void Start()
    {
        _animation=GetComponent<HashAnimNames>();
        _animator = GetComponent<Animator>();
        _selectpoint = Random.Range(0, _points.Length);
        _isWalk = true;
        _startWaitTime = 1;
        _speed = 15;
        _minDistance = 0.2f;
        _waitTime = _startWaitTime;
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[_selectpoint].position, _speed * Time.deltaTime);
        _animator.SetBool(_animation.SkeletonWalk, _isWalk);

        if (Vector2.Distance(transform.position,_points[_selectpoint].position)< _minDistance)
        {
            _isWalk = false;

            if (_waitTime<=0)
            {
                _selectpoint = Random.Range(0, _points.Length);
                _waitTime = _startWaitTime;
                Flip();
                _isWalk = true;
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
    }

    public void Flip()
    {
        _isFacingRight = !_isFacingRight;
        _flip = !_flip;
        gameObject.GetComponent<SpriteRenderer>().flipX = _flip;
    }
}
