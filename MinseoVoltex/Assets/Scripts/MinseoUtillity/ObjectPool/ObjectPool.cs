using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] m_Childs;
    [SerializeField] private Int32[] m_NumberOfChilds;
    private Dictionary<String, Queue<GameObject>> m_Pool;

    private void Awake()
    {
        if (m_Childs.Length != m_NumberOfChilds.Length) 
            throw new Exception("Object Pooling Error : Child GameObject and the number of Children do not match");

        for(int i = 0; i < m_Childs.Length; i++)
        {
            Queue<GameObject> qu = new Queue<GameObject>();
            for(int j = 0; j < m_NumberOfChilds[i]; j++)
            {
                GameObject obj = Instantiate(m_Childs[i], transform);
                qu.Enqueue(obj);
            }
        }
    }
}
