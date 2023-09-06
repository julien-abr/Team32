using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FindPictoScriptableObject")]
public class FindPictoScriptableObject : ScriptableObject
{
    public Sprite MemoryImage;

    public float TimerDuration;

    public float MalusDuration;

    public List<PictoInfo> ArrayOfPicto;


    [Serializable]
    public struct PictoInfo
    {
        public KeyCode PictoCode;
        public Vector2 PictoPosition;
    }
}
