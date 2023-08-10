using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;

//MonoBehavior를 상속받는 클래스만 해당함. 이때 두번째 인자를 true로 바꿀 시 MonoBehavior를 상속받는 모든 클래스에서 이용가능
[CustomEditor(typeof(MonoBehaviour), true)]
public class CustomInspectorButton : Editor // Editor를 상속받는다
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // 안써주면 큰일난다 (디코방 질문 채팅방 08/11 01:30분 채팅 참고)

        //target은 Editor를 상속받으면 사용할 수 있는 변수로 적용되는 대상을 전부 받아온다.
        MonoBehaviour monoBehavior = (MonoBehaviour)target;

        Type type = monoBehavior.GetType();

        //type에 들어있는 모든 함수를 가져온다 이때 Instance이여야 하고, 변수의 타입이 Public 이거나 NonPublic(private)이여야 한다.
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            //InspectorButtonAttribute 속성이 붙혀져있지 않으면 무시한다.
            if (!Attribute.IsDefined(method, typeof(InspectorButtonAttribute))) continue;
            
            InspectorButtonAttribute attribute = (InspectorButtonAttribute)Attribute.
                GetCustomAttribute(method, typeof(InspectorButtonAttribute));

            if (GUILayout.Button(attribute.Name)) //Button(이름)을 InspectorButtonAttribute.Name으로 한다
            { // 이때 Button() 함수는 클릭되었을 때 true를 반환한다.
                if (!Application.isPlaying) continue; // 게임이 현재 플레이 중이 아니면 함수를 실행시키지 않는다.

                method.Invoke(monoBehavior, null); // 해당 함수를 작동한다.
            }
        }
    }
}
