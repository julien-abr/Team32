using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static FindPictoScriptableObject;

public class InputManager : MonoBehaviour
{
    private GameManager _gameManager;
    private SetupTimer _setupSlider;

    [SerializeField]
    private List<PictoInfo> _listPicto;
    private PictoInfo _pictoToRemove;
    private bool _canRemovePicto;

    private bool _canSearchPicto;
    public void InitInput(GameManager manager, SetupTimer setupSlider)
    {
        _gameManager = manager;
        _setupSlider = setupSlider;
    }
    public void SetupFindPictoLevel(FindPictoScriptableObject currentLevelInfo)
    {
        foreach(PictoInfo pictoInfo in currentLevelInfo.ArrayOfPicto)
        {
            _listPicto.Add(pictoInfo);
        }

        _canSearchPicto = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(!_canSearchPicto) { return; }

        var allKeys = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
        foreach (var key in allKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Debug.Log("Pressed key : " + key);

                foreach(PictoInfo PictoInfo in _listPicto)
                {
                    if(PictoInfo.PictoCode == key)
                    {
                        _pictoToRemove = PictoInfo;
                        _canRemovePicto = true;
                        //Find picto object & animate
                    }
                    else
                    {
                        _setupSlider.Malus();
                    }
                }
            }
        }

        RemoveKeyIfPressed();

        if (_listPicto.Count == 0)
        {
            Debug.Log("Succeeded");
            _canSearchPicto = false;
            _gameManager.SucceededLevel();
        }
    }

    private void RemoveKeyIfPressed()
    {
        if (_canRemovePicto)
        {
            _listPicto.Remove(_pictoToRemove);
            Debug.Log("Removed key : " + _pictoToRemove.PictoCode);
            _canRemovePicto = false;
        }
    }
}
