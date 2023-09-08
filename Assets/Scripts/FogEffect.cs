using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class FogEffect : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;

    [SerializeField]
    private float _fadeTime;

    private YieldInstruction fadeInstruction = new YieldInstruction();
    public void Fade()
    {
        gameObject.SetActive(true);
        SpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        Color c = SpriteRenderer.color;
        while (elapsedTime < _fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / _fadeTime);
            SpriteRenderer.color = c;
        }
    }
}
