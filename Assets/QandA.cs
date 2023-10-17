using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    rank,
    multi,
    single,
    input
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
    public List<string>? ranking;
    public List<string>? choice;

    public Answer(List<string>? ranking, List<string>? choice) {
        this.ranking = ranking;
        this.choice = choice;
    }
}