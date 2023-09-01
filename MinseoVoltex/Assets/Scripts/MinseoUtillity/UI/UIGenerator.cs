using System;
using System.Reflection;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using UnityEngine;

public class UIGenerator : MonoBehaviour
{
    private CodeCompileUnit targetUnit;
    private CodeTypeDeclaration targetClass;

    [InspectorButton("Generate View Code")]
    private void StartSequence()
    {
        GenerateCode($"{gameObject.name}View");
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

        
    }

    private CodeMemberProperty[] GenerateMember()
    {
        Int32 childCount = gameObject.transform.childCount;
        CodeMemberProperty[] temp = new CodeMemberProperty[childCount];

        for(Int32 i = 0; i < childCount; i++)
        {
            
        }

        return temp;
    }

    private CodeTypeReference FindUIComponent(GameObject obj)
    {
        //obj.TryGetComponent()
        throw new NotImplementedException();
    }
}