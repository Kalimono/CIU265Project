using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Session : MonoBehaviour
{
    AudioSource a;
    AudioMixerGroup amg;
    List<string> participants;
    List<Question> allQuestions;
    List<Answer> rankAnswers;
    BaseQuestion currentQuestion;
    int qInd;
    Type answeredType;
    bool namesDone;
    bool namesStarted;

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        amg = a.outputAudioMixerGroup;
        amg.audioMixer.TransitionToSnapshots(new AudioMixerSnapshot[] { amg.audioMixer.FindSnapshot("distorted")}, new float[] { 1.0f, }, 1.0f );
            
        participants = new List<string>();
        allQuestions = new List<Question>();
        rankAnswers = new List<Answer>();

        // mönster på att lägga till frågor:
        // för varje single man lägger till, måste en rank ha lagts till innan, och single ska läggas till i samma ordning som rank

        //Phase 1
        allQuestions.Add(
            new Question(Type.rank, "Which group member has the longest reach?")
            .withFollowUp(new Question(Type.single, "Has !PFIRST played basketball?"), instant: false));
        allQuestions.Add(
            new Question(Type.rank, "Who is best suited to handle small animals?")
            .withFollowUp(new Question(Type.single, "!PFIRST, Do you try to save worms that are crossing the street?"), instant: false));
        allQuestions.Add(
            new Question(Type.rank, "Who is the most hygienic?")
            .withFollowUp(new Question(Type.single, "!PFIRST, in light of your top-ranking status with regard to hygiene, we would greatly appreciate your insights on ways in which the lowest-ranked participant, !PLAST, could enhance their hygiene practices."), instant: false));
        allQuestions.Add(
            new Question(Type.rank, "Which person in the group is most likely to pick up a hitchhiker?")
            .withFollowUp(new Question(Type.single, "!PFIRST, do you like movies about gladiators?"), instant: false));
        allQuestions.Add(
            new Question(Type.rank, "Who is the most law-abiding?")
            .withFollowUp(new Question(Type.single, "Has !PLAST ever broken the law?"), instant: false));

        //rankQuestion.Add(new Question(Type.rank, "Who is the best juggler?"));
        allQuestions.Add(new Question(Type.rank, "Who has the highest pain threshold?").withFollowUp
            (new Question(Type.single, "Do you dare to put your hand in the box?"), instant: true));

        allQuestions.Add(new Question(Type.rank, "Who has the most knowledge in the fantasy genre of fiction?").withFollowUp(
            new Question(Type.single, "Share reading tips"), instant: true));

        allQuestions.Add(new Question(Type.rank, "Who is most interested in true-crime?")
            .withFollowUp(new Question(Type.single, "!PFIRST, Why do you like it?"), instant: false));
        allQuestions.Add(new Question(Type.rank, "Who would enjoy being a mole for a day?")
            .withFollowUp(new Question(Type.single, "Did you mean the animal or?"), instant: false));
        allQuestions.Add(new Question(Type.rank, "Is there anyone in the group that does not believe computers are conscious?")
            .withFollowUp(new Question(Type.single, "Do you believe i pass the turing test?"), instant: false));


        currentQuestion = GetComponent<Startup>();
        currentQuestion.Rebuild(new Question(Type.single, "Welcome!"));
        qInd = -1;
        namesDone = false;

    }

    private bool StartupSession()
    {
        return currentQuestion.finished;
    }

    private bool EnterNames()
    {
        if (!namesStarted)
        {
            currentQuestion = GetComponent<NameEntry>();
            currentQuestion.Rebuild(new Question(Type.names, "Please enter your names"));
            answeredType = Type.names;
            namesStarted = true;
        }
        return currentQuestion.finished;
    }

    // Update is called once per frame
    void Update()
    {
        
        bool start = StartupSession();

        if (start && !namesDone)
            namesDone = EnterNames();




        if (currentQuestion.finished && namesDone)
        {
            if (currentQuestion.MyQ.HasFollowUp)
            {
                if (currentQuestion.MyQ.instantFollowUp)
                    allQuestions.Insert(qInd, currentQuestion.MyQ.followUp);
                else
                    allQuestions.Add(currentQuestion.MyQ.followUp);
            }

            switch (answeredType)
            {
                case Type.names:
                    participants = currentQuestion.GetAnswer().orderedNames;
                    break;
                case Type.rank:
                    rankAnswers.Add(currentQuestion.GetAnswer());
                    Debug.Log(rankAnswers.Count);
                    break;
                case Type.input:
                    break;
                case Type.multi:
                    break;
                case Type.single:
                    break;
            }

            qInd++;
            switch (allQuestions[qInd].type)
            {
                case Type.input:
                    answeredType = Type.input;
                    //TODO fönster som låter användare fylla i ett svar i en textruta
                    break;

                case Type.rank:
                    answeredType = Type.rank;
                    currentQuestion = GetComponent<RankQuestion>();
                    currentQuestion.Rebuild(allQuestions[qInd].withParticipants(participants));
                    break;

                case Type.multi:
                    answeredType = Type.multi;
                    //TODO fönster som låter användare välja mellan flera alternativ
                    break;

                case Type.single:
                    answeredType = Type.single;
                    currentQuestion = GetComponent<SingleOut>();
                    currentQuestion.Rebuild(allQuestions[qInd]);
                    rankAnswers.RemoveAt(0);
                    break;

            };
            


        }

        

    }

}
