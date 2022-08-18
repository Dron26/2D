using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class DamageButton : MonoBehaviour
{
    private Button _button;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _button=GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
    }


     void TaskOnClick()
    {
        _player.OnReceiveHit(10);
    }
}
