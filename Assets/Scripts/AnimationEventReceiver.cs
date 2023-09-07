using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    private GameManager _gameManager;

    public void Init(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    public void CallNextLevel()
    {
        Debug.Log("AnimationEventCall");
        _gameManager.SucceededLevel();
    }
}
