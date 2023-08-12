using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPooledObject : MonoBehaviour
{
    private ObjectPool m_objectPooler;

    protected virtual void Awake()
    {
        m_objectPooler = transform.parent.GetComponent<ObjectPool>();
    }

    protected virtual void OnDisable()
    {
        
    }
}
