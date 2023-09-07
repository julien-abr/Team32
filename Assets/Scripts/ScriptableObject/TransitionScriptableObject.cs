using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TransitionScriptableObject")]
public class TransitionScriptableObject : ScriptableObject
{
    public CharacterState NewState;

    public bool ColorShouldSwap;

    public TransitionEffect TransitionEffect;
}

public enum TransitionEffect
{
    None,
    FadeIn,
    FadeOut,
    FadeOutIn
}
public enum CharacterState
{
    None,
    Crawl,
    Crouch,
    Walk,
    Run,
    LookingUp
}