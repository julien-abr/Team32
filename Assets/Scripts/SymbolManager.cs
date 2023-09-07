using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SymbolManager : MonoBehaviour
{
    private List<PictoInfoWithGo> _listPictoInfoWithGo = new List<PictoInfoWithGo>();

    private PictoInfoWithGo _pictoInfoToRemove;
    private bool _canRemovePicto;

    [SerializeField]
    private GameObject _symbolGo;

    private GameManager _gameManager;
    private SetupTimer _setupSlider;

    public void Init(GameManager manager, SetupTimer setupSlider)
    {
        _gameManager = manager;
        _setupSlider = setupSlider;
    }
    public void SpawnSymbolAtPosition(FindPictoScriptableObject findPictoScriptableObject)
    {
        foreach (PictoInfo pictoInfo in findPictoScriptableObject.ArrayOfPicto)
        {
            GameObject go = Instantiate(_symbolGo, new Vector3(pictoInfo.PictoPosition.x, pictoInfo.PictoPosition.y, -1), Quaternion.identity);
            go.transform.parent = transform;
            go.name = _symbolGo.name;
            //go.GetComponent<SpriteRenderer>().sprite = pictoInfo.PictoCode.PictoSprite;
            PictoInfoWithGo pictoInfoWithGo = new PictoInfoWithGo();
            pictoInfoWithGo.PictoCode = pictoInfo.PictoCode;
            pictoInfoWithGo.GameObject = go;
            _listPictoInfoWithGo.Add(pictoInfoWithGo);
        }
    }

    public void SpawnSymbolRandomly(PictoScriptableObject pictoScriptableObject)
    {
        GameObject go = Instantiate(_symbolGo, transform.position, Quaternion.identity);
        go.transform.parent = transform;
        go.name = _symbolGo.name;
        //go.GetComponent<SpriteRenderer>().sprite = pictoScriptableObject.PictoSprite;
        PictoInfoWithGo pictoInfoWithGo = new PictoInfoWithGo();
        pictoInfoWithGo.PictoCode = pictoScriptableObject;
        pictoInfoWithGo.GameObject = go;
        _listPictoInfoWithGo.Add(pictoInfoWithGo);
    }

    public void CheckIfSymboleHasSameKeyCode(KeyCode keyPressed) //Check if any of symbols have the same key
    {
        foreach (PictoInfoWithGo pictoInfoWithGo in _listPictoInfoWithGo)
        {
            if (pictoInfoWithGo.PictoCode.PictoKeyCode == keyPressed)
            {
                _pictoInfoToRemove = pictoInfoWithGo;
                _canRemovePicto = true;
                //Find picto object & animate
            }
            else
            {
                _setupSlider.Malus();
            }
        }

        RemoveKey();

        CheckWinConditon();
    }

    private void RemoveKey()
    {
        if (_canRemovePicto)
        {
            _listPictoInfoWithGo.Remove(_pictoInfoToRemove);
            Debug.Log("Removed Symbol : " + _pictoInfoToRemove.PictoCode.PictoSymbol);
            _canRemovePicto = false;
        }
    }

    private void CheckWinConditon()
    {
        if (_listPictoInfoWithGo.Count == 0)
        {
            Debug.Log("Succeeded");
            _gameManager.SucceededLevel();
        }
    }
}

[Serializable]
public struct PictoInfoWithGo
{
    public PictoScriptableObject PictoCode;
    public GameObject GameObject;
}

