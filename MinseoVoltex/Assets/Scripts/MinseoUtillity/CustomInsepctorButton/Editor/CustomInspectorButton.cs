using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;

//MonoBehavior�� ��ӹ޴� Ŭ������ �ش���. �̶� �ι�° ���ڸ� true�� �ٲ� �� MonoBehavior�� ��ӹ޴� ��� Ŭ�������� �̿밡��
[CustomEditor(typeof(MonoBehaviour), true)]
public class CustomInspectorButton : Editor // Editor�� ��ӹ޴´�
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // �Ƚ��ָ� ū�ϳ��� (���ڹ� ���� ä�ù� 08/11 01:30�� ä�� ����)

        //target�� Editor�� ��ӹ����� ����� �� �ִ� ������ ����Ǵ� ����� ���� �޾ƿ´�.
        MonoBehaviour monoBehavior = (MonoBehaviour)target;

        Type type = monoBehavior.GetType();

        //type�� ����ִ� ��� �Լ��� �����´� �̶� Instance�̿��� �ϰ�, ������ Ÿ���� Public �̰ų� NonPublic(private)�̿��� �Ѵ�.
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            //InspectorButtonAttribute �Ӽ��� ���������� ������ �����Ѵ�.
            if (!Attribute.IsDefined(method, typeof(InspectorButtonAttribute))) continue;
            
            InspectorButtonAttribute attribute = (InspectorButtonAttribute)Attribute.
                GetCustomAttribute(method, typeof(InspectorButtonAttribute));

            if (GUILayout.Button(attribute.Name)) //Button(�̸�)�� InspectorButtonAttribute.Name���� �Ѵ�
            { // �̶� Button() �Լ��� Ŭ���Ǿ��� �� true�� ��ȯ�Ѵ�.
                if (!Application.isPlaying) continue; // ������ ���� �÷��� ���� �ƴϸ� �Լ��� �����Ű�� �ʴ´�.

                method.Invoke(monoBehavior, null); // �ش� �Լ��� �۵��Ѵ�.
            }
        }
    }
}
