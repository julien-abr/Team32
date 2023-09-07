using UnityEngine;
using System.Linq;

public class InputManager : MonoBehaviour
{
    private SetupTimer _setupSlider;
    private SymbolManager _symbolManager;

    public void Init(SymbolManager symbolManager, SetupTimer setupSlider)
    {
        _setupSlider = setupSlider;
        _symbolManager = symbolManager;
    }

    // Update is called once per frame
    void Update()
    {
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
