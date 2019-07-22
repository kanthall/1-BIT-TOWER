using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testowy : MonoBehaviour
{
    public class SomeClass
    {
    
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }


        public string Add(string str1, string str2)
        {
            return str1 + str2;
        }
    }

    private void Start()
    {
        SomeClass someClass = new SomeClass();
        Debug.Log(someClass.Add(1, 2));
        Debug.Log(someClass.Add("house ", "home"));
    }
}


