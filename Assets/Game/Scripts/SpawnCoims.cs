using UnityEngine;

[RequireComponent(typeof(HashAnimNames))]
public class SpawnCoims : MonoBehaviour
{ 
    [SerializeField] private GameObject _coin;

    private HashAnimNames _animation;
    private Animator _animator;

    private void Awake()
    {
        _animation = GetComponent<HashAnimNames>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {       
       for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(_coin, transform.GetChild(i).position, Quaternion.identity);
        }
    } 
}
