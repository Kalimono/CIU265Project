using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Qtype
{
    names,
    rank,
    multi,
    single,
    input,
    unspec
}

//public enum Category
//{
//    ethical,
//    physical,
//    intellectual
//}



public class Question {
    public Qtype type;
    public string prompt;
    public List<string>? orderedNames;
    public Question? followUp;
    public ArduinoEvent? arduinoEvt;

    public bool HasNames { get => (orderedNames != null); }
    public bool HasFollowUp { get => (followUp != null); }
    public bool HasArduinoEvent { get => (arduinoEvt != null); }
    public bool instantFollowUp;


    public Question(Qtype type, string prompt)
    {
        this.type = type;
        this.prompt = prompt;
    }

    public Question withParticipants(List<string> names)
    {
        orderedNames = names;
        return this;
    }

    public Question withFollowUp(Question q, bool instant)
    {
        followUp = q;
        instantFollowUp = instant;
        return this;
    }

    public Question withArduinoEvt(ArduinoEvent evt)
    {
        arduinoEvt = evt;
        return this;
    }

    public void performEvent(string arg)
    {
        if (arduinoEvt != null)
        {
            arduinoEvt.PerformEvent();
        }
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