using System;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using UnityEngine;
using System.Security.Permissions;

public class UIGenerator : MonoBehaviour
{
    private CodeCompileUnit targetUnit;
    private CodeTypeDeclaration targetClass;

    [InspectorButton("Generate View Code", true)]
    private void StartSequence()
    {
        GenerateCode(
            Path.Combine(
            Application.dataPath, @"Scripts/UI", gameObject.name, $"{gameObject.name}View.cs"));
    }

    private void GenerateCode(String pFileName)
    {
        //Generate Class
        targetUnit = new CodeCompileUnit();
        CodeNamespace samples = new CodeNamespace();
        targetClass = new CodeTypeDeclaration(pFileName);
        targetClass.IsClass = true;
        targetClass.TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed;
        samples.Types.Add(targetClass);
        targetUnit.Namespaces.Add(samples);

        //Generate Member
        CodeMemberField[] fields = GenerateMember();
        foreach (CodeMemberField field in fields)
        {
            targetClass.Members.Add(field);
        }

        //Generate Code
        CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
        CodeGeneratorOptions options = new CodeGeneratorOptions();
        options.BracingStyle = "C";
        using(StreamWriter sourceWriter = new StreamWriter(pFileName))
        {
            
            provider.GenerateCodeFromCompileUnit(targetUnit, sourceWriter, options);
        }
    }

    private CodeMemberField[] GenerateMember()
    {
        Int32 childCount = gameObject.transform.childCount;
        CodeMemberField[] temp = new CodeMemberField[childCount];

        for(Int32 i = 0; i < childCount; i++)
        {
            GameObject childObj = gameObject.transform.GetChild(i).gameObject;
            CodeMemberField field = new CodeMemberField();
            field.Attributes = MemberAttributes.Public;
            field.Name = childObj.name;
            field.Type = FindUIComponent(childObj);
            temp[i] = field;
        }

        return temp;
    }

    private CodeTypeReference FindUIComponent(GameObject obj)
    {
        UITypes typeFinder = new UITypes();
        Component comp = new Component();
        foreach(Type type in typeFinder)
        {
            if(obj.TryGetComponent(type, out comp))
            {
                return new CodeTypeReference(comp.GetType());
            }
        }
        throw new NotImplementedException();
    }
}