using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<ScriptableObject> ListScriptableObjects;
    private int _levelIndex = 0;

    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private SetupTimer _setupTimer;

    private ScriptableObject _currentLevelInfo;

    private void Start()
    {
        _setupTimer.InitSlider(this);
        _inputManager.InitInput(this, _setupTimer);
        StartNextLevel();
    }

    private void StartNextLevel()
    {
        ScriptableObject NextLevel = ListScriptableObjects[_levelIndex];
        _currentLevelInfo = NextLevel;

        if (NextLevel as FindPictoScriptableObject != null)
        {
            Debug.Log("Starting FindPicto level");
            FindPictoScriptableObject findPictoScriptableObject = NextLevel as FindPictoScriptableObject;
            _setupTimer.SetupSliderValue(findPictoScriptableObject.TimerDuration, findPictoScriptableObject.MalusDuration);
            _inputManager.SetupFindPictoLevel(findPictoScriptableObject);
            return;
        }

        //Same with boss
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
    }
}
