using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private int _scoreDiamonds;
    [SerializeField] private int _feverCount;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _scoreDiamondsText;
    [SerializeField] private Text _timeFeverText;

    [SerializeField] private float _time;
    [SerializeField] private float _timeFever;
    [SerializeField] private float _timeTextFever;

    [SerializeField] private GameObject playerController;

    public bool fever;

    public string nameMaterials;



    public void Start()
    {
        playerController = GameObject.Find("Joystick");

        fever = false;

        _time = 0;
        _timeFever = 0;
        _timeTextFever = 0;
        _feverCount = 0;

        _score = 0;
        _scoreDiamonds = 0;

        _scoreText.text = _score.ToString();
        _scoreDiamondsText.text = _scoreDiamonds.ToString();
        _timeFeverText.text = _timeTextFever.ToString();
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (fever == false)
        {
            if (_time >= 3 && _feverCount != 0)
            {
                _time = 0;
                _feverCount = 0;
            }

            if (_feverCount == 3)
            {
                FeverOn();
            }
        }

        else if (fever == true)
        {
            _timeFever += Time.deltaTime;

            if (_timeFever >= 5)
            {
                fever = false;

                FeverOff();

                int timeTextFever = 0;
                _timeFeverText.text = timeTextFever.ToString();
            }
        }

        if(_timeTextFever > 0)
        {
            _timeTextFever -= Time.deltaTime;

            int timeTextFever = (int)_timeTextFever;
            _timeFeverText.text = (timeTextFever + 1).ToString();
        }
    }

    public void FeverControlls()
    {
        _feverCount++;
        _time = 0;
    }
    public void Score()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
    public void ScoreDiamonds()
    {
        _scoreDiamonds++;
        _scoreDiamondsText.text = _scoreDiamonds.ToString();
    }
    
    public void FeverOn()
    {
        fever = true;

        _timeFever = 0;
        _timeTextFever = 5;
        _scoreDiamonds = 0;
        _feverCount = 0;

        playerController.GetComponent<PlayerController>().FeverOn();
    }
    public void FeverOff()
    {
        fever = false;

        playerController.GetComponent<PlayerController>().FeverOff();
    }
}
