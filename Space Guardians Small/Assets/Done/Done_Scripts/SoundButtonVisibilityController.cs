using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using AssemblyCSharp;

public class SoundButtonVisibilityController : MonoBehaviour
{
    void Start()
    {
        this.renderer.enabled = false;
    }

    void Update()
    {
        if (AppCore.CurrentStatus != AppCore.Status.LOADING && AppCore.CurrentStatus != AppCore.Status.FAST_GAME)
            this.renderer.enabled = true;
        else
            this.renderer.enabled = false;
    }
}

