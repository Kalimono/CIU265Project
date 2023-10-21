using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public partial class Session : MonoBehaviour
{

    private void CheckNames()
    {
        if (currentQuestion.MyQ.type == Qtype.names)
        {
            participants = currentQuestion.GetAnswer().orderedNames;
        }
    }

    private void CheckFollowUp()
    {
        if (currentQuestion.MyQ.HasFollowUp)
        {
            if (currentQuestion.MyQ.instantFollowUp)
                allQuestions.Insert(1, currentQuestion.MyQ.followUp.withParticipants(currentQuestion.GetAnswer().orderedNames));
            else
            {
                questionBuffer.Add(currentQuestion.MyQ.followUp.withParticipants(currentQuestion.GetAnswer().orderedNames));
            }
        }
    }

    private void CheckArduino()
    {
        if (currentQuestion.MyQ.HasArduinoEvent)
            currentQuestion.MyQ.performEvent("hey");
    }

    private void CheckMusic()
    {
        if (currentQuestion.MyQ.HasMusicEvent)
        {
            currentQuestion.MyQ.performMusicEvent(amg, null);
            print("yes");
        }
    }

}
