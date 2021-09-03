using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;
    [SerializeField] float alphaTimeScale = 1f;
    void Start()
    {


        impactCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowSplatter());
    }

    IEnumerator ShowSplatter()
    {
        impactCanvas.enabled = true;
        impactCanvas.GetComponentInChildren<Image>().CrossFadeAlpha(0f, impactTime, false);//fully transparent overtime
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
        impactCanvas.GetComponentInChildren<Image>().CrossFadeAlpha(1f, 0, true);//no longer transparent
    }
}
