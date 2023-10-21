using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public partial class Session : MonoBehaviour
{
    AudioSource a;
    AudioMixerGroup amg;

    List<string> participants;
    List<Question> allQuestions;
    List<Question> questionBuffer;
    BaseQuestion currentQuestion;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        amg = a.outputAudioMixerGroup;
            
        participants = new List<string>();
        allQuestions = new List<Question>();
        questionBuffer = new List<Question>();

        BuildQuestionaire();

    }
    
    
    
    void Update()
    {

        if (currentQuestion.finished)
        {
            CheckNames();
            CheckFollowUp();
            CheckArduino();
            CheckMusic();

            Question question = SetNextQuestion();
            

            switch (question.type)
            {
                case Qtype.start:
                    currentQuestion = GetComponent<Startup>();
                    currentQuestion.Rebuild(question);
                    break;

                case Qtype.names:
                    currentQuestion = GetComponent<NameEntry>();
                    currentQuestion.Rebuild(question);
                    break;

                case Qtype.input:
                    //TODO fönster som låter användare fylla i ett svar i en textruta
                    break;

                case Qtype.rank:
                    currentQuestion = GetComponent<RankQuestion>();
                    currentQuestion.Rebuild(question.withParticipants(participants));
                    break;

                case Qtype.multi:
                    //TODO fönster som låter användare välja mellan flera alternativ
                    break;

                case Qtype.singleOut:
                    currentQuestion = GetComponent<SingleOut>();
                    currentQuestion.Rebuild(question);
                    break;

                case Qtype.divider:
                    currentQuestion = GetComponent<Blank>();
                    currentQuestion.Rebuild(question);
                    questionBuffer.Reverse();
                    foreach (Question bufferedQ in questionBuffer)
                    {
                        allQuestions.Insert(1, bufferedQ);
                    }
                    questionBuffer = new List<Question>();
                    break;

            };

        }

    }

    private Question SetNextQuestion()
    {
        allQuestions.RemoveAt(0);
        return allQuestions[0];
    }

}
