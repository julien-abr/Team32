using UnityEngine;
using System.Linq;

public class InputManager : MonoBehaviour
{
    private SetupTimer _setupSlider;
    private SymbolManager _symbolManager;
    private GameManager _gameManager;

    public void Init(SymbolManager symbolManager, SetupTimer setupSlider, GameManager gameManager)
    {
        _setupSlider = setupSlider;
        _symbolManager = symbolManager;
        _gameManager = gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.gameState == GameState.Transition) { return; }

        var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
        foreach (var key in allKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Pressed key : " + key);
                _symbolManager.CheckIfSymboleHasSameKeyCode(key);
            }
        }
    }
}
