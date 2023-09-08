using UnityEngine;
using UnityEngine.UI;

public class SetupTimer : MonoBehaviour
{
    private GameManager _gameManager;

    [Header("Components")]
    private Image _timerImage;

    [Header("Variables")]
    private bool _canLooseTime;
    private float _timerDuration;
    private float _timerMalusDuration;

    private float _currentDuration;

    public void Awake()
    {
        _timerImage = gameObject.GetComponent<Image>();
        Debug.Log("Get timer color ref");
    }

    public void Init(GameManager manager)
    {
        _gameManager = manager;
    }
    public void SetupSliderValue(float maxDuration, float malusDuration)
    {
        _timerDuration = maxDuration;
        _timerMalusDuration = malusDuration;
        _currentDuration = _timerDuration;
        _canLooseTime = true;
    }

    public void Malus()
    {
        Debug.Log("Taking Malus");
        _currentDuration -= _timerMalusDuration;
    }

    public void Bonus()
    {
        Debug.Log("Taking Bonus");
        _currentDuration += _timerMalusDuration;
    }

    public void Update()
    {
        if (_canLooseTime)
        {
            _currentDuration -= Time.deltaTime;

            var tempColor = _timerImage.color;
            float lerp = Mathf.InverseLerp(0, _timerDuration, _currentDuration);
            float gap = 1 - lerp;
            tempColor.a = gap;
            _timerImage.color = tempColor;
            //Debug.Log(tempColor.a);

            if(_currentDuration <= 0)
            {
                TimerEnded();    
            }
        }
    }

    private void TimerEnded()
    {
        Debug.Log("TimerEnded");
        _gameManager.Loose();
        _canLooseTime = false;
    }
}
