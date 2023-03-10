using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] public InputActionProperty _menuButton;

    private void Awake()
    {
        _gameMenu.SetActive(false);
    }

    private void Update()
    {
        if (_menuButton.action.WasPressedThisFrame())
        {
            _gameMenu.SetActive(!_gameMenu.activeSelf); // set it active if inactive and viceversa
        }
    }
}
