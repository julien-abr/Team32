using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BossFightScriptableObject")]
public class BossFightScriptableObject : ScriptableObject
{
    public Sprite BossImage;

    public List<PictoScriptableObject> _listPicto;

    public float IntervalMin;

    public float IntervalMax;

    public float Life;
}
