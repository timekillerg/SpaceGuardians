using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StopRotation : MonoBehaviour
{
    private Quaternion _rotation;
    void Awake()
    {
        _rotation = gameObject.transform.rotation;

    }

    void Start()
    {
    }

    void Update()
    {
        gameObject.transform.rotation = _rotation;
    }
}

