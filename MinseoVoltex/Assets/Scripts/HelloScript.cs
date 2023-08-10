using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloScript : MonoBehaviour
{

    [InspectorButton("Hello")]
    private void TestFunction()
    {
        Debug.Log("TEST");
    }
}
