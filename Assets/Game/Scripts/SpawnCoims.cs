using UnityEngine;

public class SpawnCoims : MonoBehaviour
{ 
    [SerializeField] private GameObject _coin;

    private void Start()
    {       
       for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(_coin, transform.GetChild(i).position, Quaternion.identity);
        }
    } 
}
