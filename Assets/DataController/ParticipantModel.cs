using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Participant : MonoBehaviour
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Participant(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
