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

public interface ArduinoEvent
{
    public void PerformEvent();
}

public class Question {
    public Type type;
    public string prompt;
    public List<string>? orderedNames;
    public Question? followUp;
    public ArduinoEvent? arduinoEvt;

    public bool HasNames { get => (orderedNames != null); }
    public bool HasFollowUp { get => (followUp != null); }
    public bool HasArduinoEvent { get => (arduinoEvt != null); }
    public bool instantFollowUp;


    public Question(Type type, string prompt)
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