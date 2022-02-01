using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderController : MonoBehaviour
{
    private IEnumerator coroutine;
    private Color faderColor;
    private float alpha=0f;
    [SerializeField] public float fadeDuration;
    
    public void LaunchFadeIn()
    {
        alpha = 0f;
        coroutine = FadeIn();
        StartCoroutine(coroutine);
    }

    public void LaunchFadeOut()
    {
        alpha=1f;
        coroutine = FadeOut();
        StartCoroutine(coroutine);
    }

    private IEnumerator FadeIn()
    {
        
        while (alpha < 1)
        {
            alpha += Time.unscaledDeltaTime / fadeDuration;
            GetComponent<SpriteRenderer>().color= new Color(0f,0f,0f,alpha);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        while (alpha > 0)
        {
            alpha -= Time.unscaledDeltaTime / fadeDuration;
            GetComponent<SpriteRenderer>().color= new Color(0f,0f,0f,alpha);
            yield return null;

        }
    }
}
