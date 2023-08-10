using System;

[AttributeUsage(AttributeTargets.Method)] //�ش� �Ӽ��� Method(�Լ�)���� ���� �� �ִ�
public class InspectorButtonAttribute : Attribute // Attribute�� ��ӽ�Ų��
{
    public String Name { get; }
    public InspectorButtonAttribute(String pName)
    {
        Name = pName;
    }
}
