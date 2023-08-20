using System;
using UnityEngine;

namespace Trail
{
    public enum TrailPointType
    {
        Linear,
        CatmullRom,
    }
    public class TrailPoint : MonoBehaviour
    {
        [SerializeField] TrailPointType mType;
        public TrailPointType TrailType { get { return mType; } }
    }
}