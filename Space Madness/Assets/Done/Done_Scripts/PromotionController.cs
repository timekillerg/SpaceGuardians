using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PromotionController : MonoBehaviour
{
    public GameObject Banner;
    public float SleepTime;
    private bool isBannerClosed = false;

    void Start()
    {
        Banner.SetActive(false);
    }

    void Update()
    {
        if (!isBannerClosed && (AppCore.CurrentStatus == AssemblyCSharp.AppCore.Status.FAST_GAME_OVER ||
            AppCore.CurrentStatus == AssemblyCSharp.AppCore.Status.RESTART_FAST_GAME))
            StartCoroutine(WaitThenShow());
    }

    IEnumerator WaitThenShow()
    {
        yield return new WaitForSeconds(SleepTime);
        Banner.SetActive(true);
    }
}

