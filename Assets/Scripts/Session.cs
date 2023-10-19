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
        allQuestions.Add(new Question(Type.rank, "Which group member has the longest reach?"));
        allQuestions.Add(new Question(Type.rank, "Who is best suited to handle small animals?"));
        allQuestions.Add(new Question(Type.rank, "Who is the most hygienic?"));
        allQuestions.Add(new Question(Type.rank, "Which person in the group is most likely to pick up a hitchhiker?"));
        allQuestions.Add(new Question(Type.rank, "Who is the most law-abiding?"));

        allQuestions.Add(new Question(Type.single, "Has person played basketball?"));
        allQuestions.Add(new Question(Type.single, "person Do you try to save worms that are crossing the street?"));
        allQuestions.Add(new Question(Type.single, "Person A, in light of your top-ranking status with regard to hygiene, we would greatly appreciate your insights on ways in which the lowest-ranked participant, person B, could enhance their hygiene practices."));
        allQuestions.Add(new Question(Type.single, "person, do you like movies about gladiators?"));
        allQuestions.Add(new Question(Type.single, "Has person ever broken the law?"));


        //rankQuestion.Add(new Question(Type.rank, "Who is the best juggler?"));
        allQuestions.Add(new Question(Type.rank, "Who has the highest pain threshold?"));
        allQuestions.Add(new Question(Type.single, "Do you dare to put your hand in the box?"));

        allQuestions.Add(new Question(Type.rank, "Who has the most knowledge in the fantasy genre of fiction?"));
        allQuestions.Add(new Question(Type.single, "Share reading tips"));

        allQuestions.Add(new Question(Type.rank, "Who is most interested in true-crime?"));
        allQuestions.Add(new Question(Type.rank, "Who would enjoy being a mole for a day?"));
        allQuestions.Add(new Question(Type.rank, "Is there anyone in the group that does not believe computers are conscious?"));

        allQuestions.Add(new Question(Type.single, "Why do you like it?"));
        allQuestions.Add(new Question(Type.single, "Did you mean the animal or?"));
        allQuestions.Add(new Question(Type.single, "Do you believe i pass the turing test?"));

        currentQuestion = GetComponent<Startup>();
        currentQuestion.Rebuild("Welcome!", participants, null);


    }

    private bool StartupSession()
    {
        return currentQuestion.finished;
    }

    private bool EnterNames()
    {
        currentQuestion = GetComponent<NameEntry>();
        currentQuestion.Rebuild("please enter your names", null, null);
        answeredType = Type.names;

        qInd = -1;
        return currentQuestion.finished;
    }

    // Update is called once per frame
    void Update()
    {
        bool namesDone = false;
        bool start = StartupSession();

        if (start)
            namesDone = EnterNames();

        // Skriva in namn
        // returvärdet går in i en lista kallad participants,
        // så:
        //TODO
        //NanmeEntry.cs måste kunna ta in ett antal namn via text fields och returnera dem i ett Answer
        // från GetAnswer(). Dessutom ska NameEntry.FinishQuestion vara villkorad på om OK antal namn fyllts i.
        

        if (currentQuestion.finished && namesDone)
        {
            // redo för nästa fråga
            qInd++;
            // vid detta lag har namn fyllts i med framgång.

            // 1a switchen kollar vilken sorts fråga som nyss har kompletterats, i första fallet kommer det vara "names"
            // och då ska svaret returneras direkt till participants.
            switch (answeredType)
            {
                case Type.names:
                    participants = currentQuestion.GetAnswer().orderedNames;
                    break;

                case Type.rank:
                    rankAnswers.Add(currentQuestion.GetAnswer());
                    break;

                case Type.input:

                    break;

                case Type.multi:

                    break;

                case Type.single:

                    break;
            }

            // 2a switchen kollar vad för fråga som ställs härnäst och berättar för loopen vad för fråga den jobbar med
            // och bygger upp UI:t för frågan.

            switch (allQuestions[qInd].type)
            {
                case Type.input:
                    answeredType = Type.input;
                    //TODO fönster som låter användare fylla i ett svar i en textruta
                    break;

                case Type.rank:
                    answeredType = Type.rank;
                    // fönster som låter deltagarna lägga varandra i en rangordning
                    currentQuestion = GetComponent<RankQuestion>();
                    currentQuestion.Rebuild(allQuestions[qInd].prompt, participants, null);
                    break;

                case Type.multi:
                    answeredType = Type.multi;
                    //TODO fönster som låter användare välja mellan flera alternativ
                    break;

                case Type.single:
                    answeredType = Type.multi;
                    // fönster som riktar en fråga till en specifik deltagare, baserat på en tidigare (ranking)fråga
                    // som det funkar nu så antar frågor typade med single att det har lagts till ett answer till listan
                    // answers för varje följdfråga som ställs, och att dessa frågor ställts i samma ordning som följdfrågorna.
                    currentQuestion = GetComponent<SingleOut>();
                    currentQuestion.Rebuild(allQuestions[qInd].prompt, rankAnswers[0].orderedNames, null);
                    rankAnswers.RemoveAt(0);
                    break;

            };
            


        }

        

    }

}
