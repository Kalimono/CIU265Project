using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    names,
    rank,
    multi,
    single,
    input,
}

//public enum Category
//{
//    ethical,
//    physical,
//    intellectual
//}

public class Question {
    public Type type;
    public string prompt;

    public Question(Type type, string prompt)
    {
        this.type = type;
        this.prompt = prompt;
    }
}

public struct Answer {
    public List<string>? orderedNames;
    public List<string>? choice;

    public Answer(List<string>? ranking, List<string>? choice) {
        this.orderedNames = ranking;
        this.choice = choice;
    }
}