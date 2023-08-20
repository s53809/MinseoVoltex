using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trail;
using Unity.Mathematics;
using DG.Tweening;

[ExecuteInEditMode]
public class TrailGenerator : MonoBehaviour
{
    private TrailPoint[] mPoints;
    private LineRenderer mLine;
    private List<Vector3> mPositions = new List<Vector3>();

    [SerializeField] private Single mInterval = 0.1f;

    private Matrix4x4 mMatrix = new Matrix4x4(
        new Vector4(0, -0.5f, 1, -0.5f),
        new Vector4(1, 0, -2.5f, 1.5f),
        new Vector4(0, 0.5f, 2, -1.5f),
        new Vector4(0, 0, -0.5f, 0.5f)
        );

    private void Start()
    {
        mLine = GetComponent<LineRenderer>();
        mLine.useWorldSpace = true;
        Drawline();

    }

    private void Update()
    {
        
    }

    private Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, Single t)
    {
        Matrix4x4 tMatrix = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(t, 0, 0, 0),
            new Vector4((Single)Math.Pow(t, 2), 0, 0, 0),
            new Vector4((Single)Math.Pow(t, 3), 0, 0, 0));

        Debug.Log("-----------------");

        Debug.Log($"{p0}, {p1}, {p2}, {p3}, {t}");
        
        Debug.Log(tMatrix);

        Matrix4x4 pMatrix = new Matrix4x4(
                new Vector4(p0.x, p1.x, p2.x, p3.x),
                new Vector4(p0.y, p1.y, p2.y, p3.y),
                new Vector4(p0.z, p1.z, p2.z, p3.z),
                new Vector4(0, 0, 0, 0));

        Debug.Log(mMatrix);

        Debug.Log(pMatrix);


        Matrix4x4 Output = tMatrix * mMatrix * pMatrix;

        Debug.Log(Output);
        
        Debug.Log("-----------------");

        return new Vector3(Output.m00, Output.m01, Output.m02);
    }

    [InspectorButton("Draw Line", true)]
    private void Drawline()
    {
        mPoints = new TrailPoint[transform.childCount];
        Debug.Log(transform.childCount);
        var points = GetComponentsInChildren<TrailPoint>();
        for (Int32 i = 0; i < points.Length; i++)
        {
            Debug.Log(points[i].name);
            mPoints[i] = points[i];
        }

        mPositions.Clear();
        mPositions.Add(mPoints[0].transform.position);
        for (int i = 0; i < mPoints.Length - 1; i++)
        {
            if(mPoints[i].TrailType == TrailPointType.Linear)
                mPositions.Add(mPoints[i + 1].transform.position);
            else
            {
                Vector3 p0 = new Vector3(0, 0, 0);
                Vector3 p1 = new Vector3(0, 0, 0);
                Vector3 p2 = new Vector3(0, 0, 0);
                Vector3 p3 = new Vector3(0, 0, 0);
                if (i == 0)
                {
                    //#todo : 캣멀롬 시작점 끝점 예외처리
                }
                else if (i == mPoints.Length - 1)
                {

                }
                else
                {
                    p0 = mPoints[i - 1].transform.position;
                    p1 = mPoints[i].transform.position;
                    p2 = mPoints[i + 1].transform.position;
                    p3 = mPoints[i + 2].transform.position;
                }
                for (Single t = 0; t <= 1.1f; t += mInterval)
                    mPositions.Add(CatmullRom(p0, p1, p2, p3, t));
            }
        }

        mLine.positionCount = mPositions.Count;
        for (int i = 0; i < mPositions.Count; i++)
            mLine.SetPosition(i, mPositions[i]);
    }
}
