using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Переменные

    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _target;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerPoint;

    [SerializeField] private GameObject _tail;
    [SerializeField] private GameObject _tailPoint;

    [SerializeField] private GameObject _tail_2;
    [SerializeField] private GameObject _tailPoint_2;

    [SerializeField] private GameObject _tail_3;
    [SerializeField] private GameObject _tailPoint_3;

    [SerializeField] private GameObject _tail_4;

    [SerializeField] private float _speed;
    public float _speedCorrect;

    [SerializeField] private bool _fever;
    #endregion


    private void Start()
    {
        _fever = false;
    }

    private void Update()
    {
        Vector3 movePos = new Vector3(_target.position.x, _target.position.y, 4f);
        Vector3 movePosTail = new Vector3(_playerPoint.transform.position.x, _playerPoint.transform.position.y, 2.75f);
        Vector3 movePosTail_2 = new Vector3(_tailPoint.transform.position.x, _tailPoint.transform.position.y, 1.75f);
        Vector3 movePosTail_3 = new Vector3(_tailPoint_2.transform.position.x, _tailPoint_2.transform.position.y, 0.9f);
        Vector3 movePosTail_4 = new Vector3(_tailPoint_3.transform.position.x, _tailPoint_3.transform.position.y, 0.15f);

        // Движение игрока
        _player.transform.LookAt(_target);
        _player.transform.position = Vector3.MoveTowards(_player.transform.position, movePos, Time.deltaTime * _speed );
        
        // Движение хвоста
        _tail.transform.LookAt(_playerPoint.transform);
        _tail.transform.position = Vector3.MoveTowards(_tail.transform.position, movePosTail, Time.deltaTime * (_speed -0.1f));

        // Движение хвоста №2
        _tail_2.transform.LookAt(_tailPoint.transform);
        _tail_2.transform.position = Vector3.MoveTowards(_tail_2.transform.position, movePosTail_2, Time.deltaTime * (_speed - -0.1f));

        // Движение хвоста №3
        _tail_3.transform.LookAt(_tailPoint_2.transform);
        _tail_3.transform.position = Vector3.MoveTowards(_tail_3.transform.position, movePosTail_3, Time.deltaTime * (_speed - -0.1f));

        // Движение хвоста №4
        _tail_4.transform.LookAt(_tailPoint_3.transform);
        _tail_4.transform.position = Vector3.MoveTowards(_tail_4.transform.position, movePosTail_4, Time.deltaTime * (_speed - -0.1f));

        if(_fever == true)
        {
            _target.position = Vector3.Lerp(_leftPoint.position, _rightPoint.position, 0.5f);
        }
    }

    
    //Получение данных от слайдера и передача этих данных в вектора
    public void SetNormalizedPosition(float position)
    {
        if(_fever == true)
        {
            _target.position = Vector3.Lerp(_leftPoint.position, _rightPoint.position, 0.5f);
        }
        
        else
        {
            _target.position = Vector3.Lerp(_leftPoint.position, _rightPoint.position, position);
        }
        
    }
    public void FeverOn()
    {
        //Debug.Log("FeverOn");

        _fever = true;
        _speedCorrect = 3;
    }
    public void FeverOff()
    {
        //Debug.Log("FeverOff");

        _fever = false;
        _speedCorrect = 1;
    }
}

