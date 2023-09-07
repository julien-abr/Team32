using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterState State;

    [SerializeField]
    private SpriteRenderer _plateformSprite;

    private SpriteRenderer _characterSprite;

    [SerializeField]
    private Color _black;

    [SerializeField]
    private Color _white;

    public void Start()
    {
        _characterSprite = GetComponent<SpriteRenderer>();
    }

    public void SetState(CharacterState newState)
    {
        State = newState;
        //Change animation
    }

    public void ColorSwaper()
    {
        //if the character is black
        if(_characterSprite.color == _black)
        {
            SetCharacterWhiteAndPlateformBlack();
        }
        else
        {
            SetCharacterBlackAndPlateformWhite();
        }
    }

    private void SetCharacterWhiteAndPlateformBlack()
    {
        _characterSprite.color = _white;
        _plateformSprite.color = _black;
    }

    private void SetCharacterBlackAndPlateformWhite()
    {
        _characterSprite.color = _black;
        _plateformSprite.color = _white;
    }

}
