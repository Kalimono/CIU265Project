using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWaitingRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum Type
{
    rank,
    multi,
    single,
    input
}

public enum Category
{
    ethical,
    physical,
    intellectual
}

public class Question {
    int phase;
    public Type type;
    Category category;
    public string prompt;
    //bool followUp;
    Answer answer;

    public Question(Type type, string prompt)
    {
        this.type = type;
        this.prompt = prompt;
    }

    public void answerQuestion() {
        this.answer = new Answer();
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