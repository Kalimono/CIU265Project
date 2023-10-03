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

public enum Category
{
    rank,
    multi,
    single
}

public class Question {
    int phase;
    int category;
    string prompt;
    bool followUp;
    Answer answer;

    public Question(int phase, int category, string prompt, bool followUp)
    {
        this.phase = phase;
        this.category = category;
        this.prompt = prompt;
        this.followUp = followUp;
    }

    public void answerQuestion() {
        this.answer = new Answer();
    }
}

public struct Answer {
    string personFirst;
    string personLast;
    List<string> ranking;
    List<string> choice;

    public Answer(string? first, string? last, List<string>? ranking, List<string>? choice) {
        this.personFirst = first;
        this.personLast = last;
        this.ranking = ranking;
        this.choice = choice;
    }
}