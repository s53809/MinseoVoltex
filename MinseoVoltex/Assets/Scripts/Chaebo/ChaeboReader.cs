using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ChaeboReader : MonoSingleton<ChaeboReader>
{
    [SerializeField] private Int32 hello;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        
    }
}
