using System;
using System.Collections;

public class UITypes : IEnumerator, IEnumerable
{
    private Type[] types = new Type[]
    {
        typeof(UnityEngine.UI.Text),
        typeof(UnityEngine.UI.Button),
        typeof(UnityEngine.UI.Image),
        typeof(UnityEngine.UI.Dropdown),
        typeof(UnityEngine.UI.InputField),
        typeof(UnityEngine.UI.ScrollRect),
        typeof(UnityEngine.GameObject),
    };
    private Int32 index = 0;
    public object Current => types[index];

    public IEnumerator GetEnumerator() => types[index] as IEnumerator;

    public bool MoveNext()
    {
        if (index < types.Length)
        {
            index++;
            return true;
        }
        else return false;
    }

    public void Reset() => index = 0;
}