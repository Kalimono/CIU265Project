using System;
using UnityEngine;

public class SoundActions : ScriptableObject
{
    public static Action<float> JumpToTime;

    public static Action IncrementSound;
}