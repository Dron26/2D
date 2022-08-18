using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class AddHealthButton : MonoBehaviour
{
    private Button _button;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        _player.AddHelth(10);
    }
}