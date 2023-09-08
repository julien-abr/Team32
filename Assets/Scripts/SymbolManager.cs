using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SymbolManager : MonoBehaviour
{
    private List<PictoInfoWithGo> _listPictoInfoWithGo = new List<PictoInfoWithGo>();

    private List<PictoInfoWithGo> _listPictoInfoWithGoFound = new List<PictoInfoWithGo>();

    private PictoInfoWithGo _pictoInfoToRemove;
    private bool _canRemovePicto;

    [SerializeField]
    private GameObject _symbolGo;
    [SerializeField]
    private GameObject _fogGo;

    [SerializeField]
    private GameObject _fogGoParent;

    private GameManager _gameManager;
    private SetupTimer _setupSlider;

    [SerializeField]
    private Color _green;

    public void Init(GameManager manager, SetupTimer setupSlider)
    {
        _gameManager = manager;
        _setupSlider = setupSlider;
    }
    public void SpawnSymbolAtPosition(FindPictoScriptableObject findPictoScriptableObject)
    {
        ResetSymbol();

        foreach (PictoInfo pictoInfo in findPictoScriptableObject.ArrayOfPicto)
        {
            //Creating goFog
            GameObject goFog = Instantiate(_fogGo, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
            goFog.transform.parent = _fogGoParent.transform;
            goFog.GetComponent<SpriteRenderer>().sprite = pictoInfo.PictoCode.PictoFogSprite;

            //Creation symbole go
            GameObject go = Instantiate(_symbolGo, new Vector3(pictoInfo.PictoPosition.x, pictoInfo.PictoPosition.y, -1), Quaternion.identity);
            go.transform.parent = transform;
            go.name = _symbolGo.name;
            go.transform.localScale = go.transform.localScale * pictoInfo.PictoCode.ScaleMultiplier;
            SpriteRenderer spriteRenderer = go.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = pictoInfo.PictoCode.PictoSprite;
            spriteRenderer.color = pictoInfo.PictoCode.ColorAlpha;

            //Creating struct and add to list
            PictoInfoWithGo pictoInfoWithGo = new PictoInfoWithGo();
            pictoInfoWithGo.PictoCode = pictoInfo.PictoCode;
            pictoInfoWithGo.GameObject = go;
            pictoInfoWithGo.FogGameObject = _fogGo;

            _listPictoInfoWithGo.Add(pictoInfoWithGo);
        }
    }

    public void SpawnSymbolRandomly(PictoScriptableObject pictoScriptableObject)
    {
        /*ResetSymbol();

        GameObject go = Instantiate(_symbolGo, transform.position, Quaternion.identity);
        go.transform.parent = transform;
        go.name = _symbolGo.name;
        go.GetComponent<SpriteRenderer>().sprite = pictoScriptableObject.PictoSprite;
        PictoInfoWithGo pictoInfoWithGo = new PictoInfoWithGo();
        pictoInfoWithGo.PictoCode = pictoScriptableObject;
        pictoInfoWithGo.GameObject = go;
        pictoInfoWithGo.FogGameObject = _fogGo;
        _listPictoInfoWithGo.Add(pictoInfoWithGo);*/
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
            break;

        }

        RemoveKey();

        CheckWinConditon();
    }

    private void RemoveKey()
    {
        if (_canRemovePicto)
        {
            _listPictoInfoWithGoFound.Add(_pictoInfoToRemove);
            _listPictoInfoWithGo.Remove(_pictoInfoToRemove);
            _pictoInfoToRemove.GameObject.GetComponent<SpriteRenderer>().color = _green;
            //Destroy(_pictoInfoToRemove.FogGameObject);
            //FogEffect fogEffect = _pictoInfoToRemove.FogGameObject.GetComponent<FogEffect>();
            //fogEffect.Fade();

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

    private void ResetSymbol()
    {
        foreach(PictoInfoWithGo pictoInfoWithGo in _listPictoInfoWithGoFound)
        {
            Destroy(pictoInfoWithGo.GameObject);
        }

        _listPictoInfoWithGoFound.Clear();

        DestroyFogChildGo();
    }

    private void DestroyFogChildGo()
    {
        foreach (Transform child in _fogGoParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}

[Serializable]
public struct PictoInfoWithGo
{
    public PictoScriptableObject PictoCode;
    public GameObject GameObject;
    public GameObject FogGameObject;
}

