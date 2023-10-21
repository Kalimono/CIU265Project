using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Qtype
{
    start,
    names,
    rank,
    multi,
    singleOut,
    input,
    divider
}

#nullable enable
public class Question {
    public Qtype type;
    public string prompt;
    public List<string>? orderedNames;
    public Question? followUp;
    public ArduinoEvent? arduinoEvt;
    public MusicEvent? musicEvt;

    public bool HasNames { get => (orderedNames != null); }
    public bool HasFollowUp { get => (followUp != null); }
    public bool HasArduinoEvent { get => (arduinoEvt != null); }
    public bool HasMusicEvent { get => (musicEvt != null); }
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

    public Question withMusicEvt(MusicEvent evt)
    {
        musicEvt = evt;
        return this;
    }



    public void performEvent(string arg)
    {
        if (arduinoEvt != null)
        {
            arduinoEvt.PerformEvent();
        }
    }

    public void performMusicEvent(AudioMixerGroup amg, bool? TF)
    {
        if (musicEvt != null)
        {
            musicEvt.Perform(amg, TF);
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