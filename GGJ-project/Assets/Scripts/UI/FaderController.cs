using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderController : MonoBehaviour
{
    private IEnumerator coroutine;
    private Color faderColor;
    private float alpha=0f;

    public void LaunchFadeIn()
    {
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
        while(alpha<1f)
        {
            yield return new WaitForSeconds(0.02f);
            alpha+=0.05f;
            GetComponent<SpriteRenderer>().color= new Color(0f,0f,0f,alpha);
        }
    }

    private IEnumerator FadeOut()
    {
        while(alpha>0f)
        {
            yield return new WaitForSeconds(0.02f);
            alpha-=0.05f;
            GetComponent<SpriteRenderer>().color= new Color(0f,0f,0f,alpha);
        }
    }
}
