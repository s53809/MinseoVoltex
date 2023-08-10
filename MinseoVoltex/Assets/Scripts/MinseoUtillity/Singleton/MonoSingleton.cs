using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour
{
    private T m_instance;
    public T Instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = GetComponent<T>();
                return m_instance;
            }
            else
            {
                return m_instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (m_instance != null) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
