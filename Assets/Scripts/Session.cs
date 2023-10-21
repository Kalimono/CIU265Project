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
    BaseQuestion currentQuestion;
    

    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        amg = a.outputAudioMixerGroup;
        //amg.audioMixer.TransitionToSnapshots(new AudioMixerSnapshot[] { amg.audioMixer.FindSnapshot("distorted")}, new float[] { 1.0f, }, 1.0f );
            
        participants = new List<string>();
        allQuestions = new List<Question>();

        //allQuestions.Add(
        //    new Question(Qtype.rank, "Which group member has the longest reach?")
        //    .withFollowUp(new Question(Qtype.single, "Has !PFIRST played basketball?"), instant: false));
        //allQuestions.Add(
        //    new Question(Qtype.rank, "Who is best suited to handle small animals?")
        //    .withFollowUp(new Question(Qtype.single, "!PFIRST, Do you try to save worms that are crossing the street?"), instant: false)
        //    .withArduinoEvt(new Shake()));
        //allQuestions.Add(
        //    new Question(Qtype.rank, "Who is the most hygienic?")
        //    .withFollowUp(new Question(Qtype.single, "!PFIRST, in light of your top-ranking status with regard to hygiene, we would greatly appreciate your insights on ways in which the lowest-ranked participant, !PLAST, could enhance their hygiene practices."), instant: false));
        //allQuestions.Add(
        //    new Question(Qtype.rank, "Which person in the group is most likely to pick up a hitchhiker?")
        //    .withFollowUp(new Question(Qtype.single, "!PFIRST, do you like movies about gladiators?"), instant: false));
        //allQuestions.Add(
        //    new Question(Qtype.rank, "Who is the most law-abiding?")
        //    .withFollowUp(new Question(Qtype.single, "Has !PLAST ever broken the law?"), instant: false)
        //    .withArduinoEvt(new Shake())
        //    );

        //rankQuestion.Add(new Question(Type.rank, "Who is the best juggler?"));
        allQuestions.Add(new Question(Qtype.unspec, ""));
        allQuestions.Add(new Question(Qtype.rank, "Who has the highest pain threshold?").withFollowUp
            (new Question(Qtype.single, "Do you dare to put your hand in the box?"), instant: true)
            .withMusicEvt(new RemoveHighPass()));

        allQuestions.Add(new Question(Qtype.rank, "Who has the most knowledge in the fantasy genre of fiction?").withFollowUp(
            new Question(Qtype.single, "Share reading tips"), instant: true)
            .withMusicEvt(new AddDistortion()));

        allQuestions.Add(new Question(Qtype.rank, "Who is most interested in true-crime?")
            .withFollowUp(new Question(Qtype.single, "!PFIRST, Why do you like it?"), instant: false));
        allQuestions.Add(new Question(Qtype.rank, "Who would enjoy being a mole for a day?")
            .withFollowUp(new Question(Qtype.single, "Did you mean the animal or?"), instant: false));
        allQuestions.Add(new Question(Qtype.rank, "Is there anyone in the group that does not believe computers are conscious?")
            .withFollowUp(new Question(Qtype.single, "Do you believe i pass the turing test?"), instant: false));


        currentQuestion = GetComponent<Startup>();
        currentQuestion.Rebuild(new Question(Qtype.unspec,
            "Hello!\n" +
            "Before entering a door, please fill out this form.\n" +
            "You will find out which door to enter at the end!" +
            "\nStart by clicking the button."));
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
            currentQuestion.Rebuild(new Question(Qtype.names, "Please put all your names in here, one at a time:"));
            namesStarted = true;
        }
        return currentQuestion.finished;
    }

    private void CheckFollowUp()
    {
        if (currentQuestion.MyQ.HasFollowUp)
        {
            if (currentQuestion.MyQ.instantFollowUp)
                allQuestions.Insert(0, currentQuestion.MyQ.followUp.withParticipants(currentQuestion.MyQ.orderedNames));
            else
                allQuestions.Add(currentQuestion.MyQ.followUp.withParticipants(currentQuestion.MyQ.orderedNames));
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


    bool namesDone;
    bool namesStarted;
    // Update is called once per frame
    void Update()
    {
        bool start = StartupSession();

        if (start && !namesDone)
        {
            namesDone = EnterNames();
            participants = currentQuestion.GetAnswer().orderedNames;
        }

        if (currentQuestion.finished && namesDone)
        {
            allQuestions.RemoveAt(0);
            CheckFollowUp();
            CheckArduino();
            CheckMusic();

            switch (allQuestions[0].type)
            {
                case Qtype.input:
                    //TODO fönster som låter användare fylla i ett svar i en textruta
                    break;

                case Qtype.rank:
                    currentQuestion = GetComponent<RankQuestion>();
                    currentQuestion.Rebuild(allQuestions[0].withParticipants(participants));
                    break;

                case Qtype.multi:
                    //TODO fönster som låter användare välja mellan flera alternativ
                    break;

                case Qtype.single:
                    currentQuestion = GetComponent<SingleOut>();
                    currentQuestion.Rebuild(allQuestions[0]);
                    break;

            };
            


        }

        

    }

}
