using System;
using System.Collections.Generic;
using UnityEngine;
using Trail;
using Spline;

[ExecuteInEditMode]
public class TrailGenerator : MonoBehaviour
{
    private TrailPoint[] mPoints;
    private LineRenderer mLine;
    private List<Vector3> mPositions = new List<Vector3>();

    [SerializeField] private Single mInterval = 0.1f;

    private void Start()
    {
        mLine = GetComponent<LineRenderer>();
        mLine.useWorldSpace = true;
        Drawline();

    }

    private void Update()
    {
        
    }

    [InspectorButton("Draw Line", true)]
    private void Drawline()
    {
        mPoints = new TrailPoint[transform.childCount];
        var points = GetComponentsInChildren<TrailPoint>();
        for (Int32 i = 0; i < points.Length; i++)
            mPoints[i] = points[i];

        mPositions.Clear();
        mPositions.Add(mPoints[0].transform.position);
        for (Int32 i = 0; i < mPoints.Length - 1; i++)
        {
            if(mPoints[i].TrailType == TrailPointType.Linear)
                mPositions.Add(mPoints[i + 1].transform.position);
            else
            {
                Vector3 p0, p1, p2, p3;
                p1 = mPoints[i].transform.position;
                p2 = mPoints[i + 1].transform.position;
                if (i == 0) //first dot
                {
                    p0 = (2 * mPoints[i].transform.position) - mPoints[i + 1].transform.position;
                    p3 = mPoints[i + 2].transform.position;
                }
                else if (i == mPoints.Length - 2) //last dot
                {
                    p0 = mPoints[i - 1].transform.position;
                    p3 = (2 * mPoints[i + 1].transform.position) - mPoints[i].transform.position;
                }
                else
                {
                    p0 = mPoints[i - 1].transform.position;
                    p3 = mPoints[i + 2].transform.position;
                }
                for (Single t = 0; t <= 1.1f; t += mInterval)
                    mPositions.Add(CatmullRom.Calculate(p0, p1, p2, p3, t));
            }
        }

        mLine.positionCount = mPositions.Count;
        for (Int32 i = 0; i < mPositions.Count; i++)
            mLine.SetPosition(i, mPositions[i]);
    }
}
