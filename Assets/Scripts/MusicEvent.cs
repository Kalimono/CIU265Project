using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public interface MusicEvent
{
    public void Perform(AudioMixerGroup amg, bool? TF);
}

public class RemoveHighPass : MusicEvent
{
    public void Perform(AudioMixerGroup amg, bool? TF)
    {
        AudioMixerSnapshot s = amg.audioMixer.FindSnapshot("highPassOff");
        amg.audioMixer.TransitionToSnapshots(
            new AudioMixerSnapshot[] { s },
            new float[] { 1.0f },
            1.0f);
    }
}

public class AddDistortion : MusicEvent
{
    public void Perform(AudioMixerGroup amg, bool? TF)
    {
        AudioMixerSnapshot s = amg.audioMixer.FindSnapshot("distorted");
        amg.audioMixer.TransitionToSnapshots(
            new AudioMixerSnapshot[] { s },
            new float[] { 0.5f },
            5.0f);
    }
}