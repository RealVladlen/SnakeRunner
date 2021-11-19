using UnityEngine;

public class MoveLocation : MonoBehaviour
{
    // Движение платформы локации
    private GameObject _location;

    private GameObject _playerController;

    [SerializeField] private float _speed;

    private void Start()
    {
        _playerController = GameObject.Find("Joystick");
        _location = gameObject;
    }
    void Update()
    {
        _location.transform.Translate(0, 0, _speed * _playerController.GetComponent<PlayerController>()._speedCorrect);
    }
}
