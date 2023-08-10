using System;

[AttributeUsage(AttributeTargets.Method)] //해당 속성은 Method(함수)에만 붙힐 수 있다
public class InspectorButtonAttribute : Attribute // Attribute를 상속시킨다
{
    public String Name { get; }
    public InspectorButtonAttribute(String pName)
    {
        Name = pName;
    }
}
