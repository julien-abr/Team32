using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FogEffect : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    [SerializeField]
    private float _fadeTime;

    public void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Fade()
    {
        Debug.Log("Fade");
        SpriteRenderer.DOFade(0, _fadeTime);
        StartCoroutine(DestroyTime());
    }

    public IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(_fadeTime);
        Destroy(gameObject);
    }
}
