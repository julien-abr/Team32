
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PictoScriptableObject")]
public class PictoScriptableObject : ScriptableObject
{
    public Symbol PictoSymbol;

    public Sprite PictoSprite;

    public KeyCode PictoKeyCode;

    public Sprite PictoFogSprite;
}

public enum Symbol
{
    Minus,
    Plus,
    Zero,
    One,
    Interdiction,
    Checkmark,
    Interogation,
    Exclamation,
    Stop,
    AntiClockwise,
    Clockwise,
    Factory,
    Wrench,
    StopWithRotation,
    Helm,
    Sandglass,
    Skull,
    heart,
    Arrow,
    Finger,
    Mouth,
    Hand,
    Music,
    Eye
}
