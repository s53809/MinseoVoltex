using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoPooledObject
{
    private static readonly Single startYPos = 18f;
    private static readonly Single targetYPos = 0f;

    private Double mStartTime;
    private Double mEndTime;
    private Double t;

    public override void Spawn()
    {
        base.Spawn();
        mStartTime = Time.timeSinceLevelLoadAsDouble;
        t = 0;
        transform.position = new Vector3(transform.position.x, startYPos, 0);
    }

    public void SpawnSetting(Double pEndTime)
    {
        mEndTime = pEndTime;
    }

    private void Update()
    {
        t = (Time.timeSinceLevelLoadAsDouble - mStartTime) / (mEndTime - mStartTime);
        //Single curYPos = 
    }
}
