using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Engine Engine;

    [Header("Level Creation")]
    [SerializeField]
    private List<ScriptableObject> ListScriptableObjects;
    private int _levelIndex = 0;
    

    [Header("ScriptsVar")]
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private SymbolManager _symbolManager;
    [SerializeField]
    private SetupTimer _setupTimer;
    [SerializeField]
    private TransitionManager _transitionManager;
    [SerializeField]
    private AnimationEventReceiver _animationEventReceiver;

    [Header("BackgroundSprite")]
    [SerializeField]
    private SpriteRenderer _backgroundSprite;

    [Header("GameOver")]
    public bool _gameEnded;
    [SerializeField]
    private GameObject _gameOverObject;

    private ScriptableObject _currentLevelInfo;

    private void Start()
    {
        _animationEventReceiver.Init(this);
        _setupTimer.Init(this);
        _inputManager.Init(_symbolManager, _setupTimer);
        _symbolManager.Init(this, _setupTimer);
        StartNextLevel();
    }

    private void StartNextLevel()
    {
        ScriptableObject NextLevel = ListScriptableObjects[_levelIndex];
        _currentLevelInfo = NextLevel;

        switch(NextLevel)
        {
            case FindPictoScriptableObject findPictoScriptableObject:
                Debug.Log("Starting FindPicto level");
                SetupUI_FindPicto(findPictoScriptableObject);
                _setupTimer.SetupSliderValue(findPictoScriptableObject.TimerDuration, findPictoScriptableObject.MalusDuration);
                break;
            case BossFightScriptableObject bossFightScriptableObject:
                Debug.Log("Starting Boss Level");
                _backgroundSprite.sprite = bossFightScriptableObject.BossImage;
                break;
            case TransitionScriptableObject transitionScriptableObject:
                Debug.Log("Starting Transition Level");
                _transitionManager.SetupTransition(transitionScriptableObject);
                break;
        }
    }

    public void SucceededLevel()
    {
        //Check if there is a next level, if not call win()
        if(ExistNextLevel())
        {
            StartNextLevel();
        }
        else
        {
            Win();
        }
    }

    private bool ExistNextLevel()
    {
        _levelIndex++;
        if(ListScriptableObjects.Count > _levelIndex)
        {
            return true;
        }
        
        return false;
    }

    private void Win()
    {
        Debug.Log("U Win");
    }

    public void Loose()
    {
        Debug.Log("U Loose");
        _gameEnded = true;
        _gameOverObject.SetActive(true);
    }


    private void SetupUI_FindPicto(FindPictoScriptableObject findPictoScriptableObject)
    {
        _backgroundSprite.sprite = findPictoScriptableObject.MemoryImage;
        _symbolManager.SpawnSymbolAtPosition(findPictoScriptableObject);
        SetCharacterState();
    }

    private void SetCharacterState()
    {

    }
}

public enum Engine
{
    PC,
    Terminal,
}
