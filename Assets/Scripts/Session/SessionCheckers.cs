using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public partial class Session : MonoBehaviour
{

    private void CheckNames()
    {
        if (currentScreen.MyQ.type == Qtype.names)
        {
            participants = currentScreen.GetAnswer().orderedNames;
        }
    }

    private void CheckFollowUp()
    {
        if (currentScreen.MyQ.HasFollowUp)
        {
            if (currentScreen.MyQ.instantFollowUp)
                allQuestions.Insert(1, currentScreen.MyQ.followUp.withParticipants(currentScreen.GetAnswer().orderedNames));
            else
            {
                questionBuffer.Add(currentScreen.MyQ.followUp.withParticipants(currentScreen.GetAnswer().orderedNames));
            }
        }
    }

    private void CheckArduino()
    {
        if (currentScreen.MyQ.HasArduinoEvent)
            currentScreen.MyQ.performEvent("hey");
    }

    private void CheckMusic()
    {
        if (currentScreen.MyQ.HasMusicEvent)
        {
            currentScreen.MyQ.performMusicEvent(amg, null);
            print("yes");
        }
    }

}
