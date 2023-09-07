using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public CharacterState State;

    [Header("Variables")]
    [SerializeField]
    private Image _plateformImg;
    [SerializeField]
    private Image _characterImg;
    [SerializeField]
    private Animator _characterAnimator;
    [SerializeField]
    private Animator _transitionAnimator;

    [SerializeField]
    private Color _black;
    [SerializeField]
    private Color _white;

    public void SetupTransition(TransitionScriptableObject transitionData)
    {
       if(transitionData.ColorShouldSwap)
       {
            SwapColor();
       }

       SetState(transitionData.NewState);
       SetTransitionAnim(transitionData.TransitionEffect);
    }

    private void SwapColor()
    {
        if (_characterImg.color == _black)
        {
            SetSpriteWhite();
        }
        else
        {
            SetSpriteBlack();
        }
    }

    private void SetState(CharacterState newState)
    {
        State = newState;
        switch(State)
        {
            case CharacterState.Crawl:
                _characterAnimator.SetTrigger("SetCrawl");
                break;
            case CharacterState.Crouch:
                _characterAnimator.SetTrigger("SetCrouch");
                break;
            case CharacterState.Walk:
                _characterAnimator.SetTrigger("SetWalk");
                break;
            case CharacterState.Run:
                _characterAnimator.SetTrigger("SetRun");
                break;
            case CharacterState.LookingUp:
                _characterAnimator.SetTrigger("SetLookingUp");
                break;
        }
    }

    private void SetTransitionAnim(TransitionEffect transitionEffect)
    {
        switch(transitionEffect)
        {
            case TransitionEffect.FadeIn:
                _transitionAnimator.SetTrigger("SetFadeIn");
                break;
            case TransitionEffect.FadeOut:
                _transitionAnimator.SetTrigger("SetFadeOut");
                break;
            case TransitionEffect.FadeOutIn:
                _transitionAnimator.SetTrigger("SetFadeOut_In");
                break;
        }
    }

    private void SetSpriteWhite()
    {
        _characterImg.color = _white;
        _plateformImg.color = _white;
    }

    private void SetSpriteBlack()
    {
        _characterImg.color = _black;
        _plateformImg.color = _black;
    }

}
