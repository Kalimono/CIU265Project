using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;






public class Session : MonoBehaviour
{
    private bool namesComplete;
    AudioSource a;
    AudioMixerGroup amg;
    List<string> participants;
    List<Question> rankQuestion;
    List<List<string>> rankings;
    List<Question> followUps;
    List<Answer> answers;
    
     
    NameEntry name;
    BaseQuestion currentQuestion;
    public bool buildNameEntry;
    public bool buildranking;

    int qInd;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<AudioSource>();
        amg = a.outputAudioMixerGroup;
        amg.audioMixer.TransitionToSnapshots(new AudioMixerSnapshot[] { amg.audioMixer.FindSnapshot("distorted")}, new float[] { 1.0f, }, 1.0f );
            
        participants = new List<string>();
        rankQuestion = new List<Question>();
        answers = new List<Answer>();

        participants.Add("Heinrich");
        participants.Add("Job");
        participants.Add("Greger");
        participants.Add("Majken");
        participants.Add("Hjulia");
        rankQuestion.Add(new Question(Type.rank, "Which group-member has the longest reach?"));
        //rankQuestion.Add(new Question(Type.rank, "Who is the kindest to small animals?"));
        //rankQuestion.Add(new Question(Type.rank, "Who is the most hygienic?"));
        //rankQuestion.Add(new Question(Type.rank, "Which person in the group is most likely to pick up a hitchhiker?"));
        //rankQuestion.Add(new Question(Type.rank, "Who is the most law-abiding?"));

        rankQuestion.Add(new Question(Type.single, "Has person played basketball?"));
        //rankQuestion.Add(new Question(Type.single, "person Do you try to save worms that are crossing the street?"));
        //rankQuestion.Add(new Question(Type.single, "Person A, in light of your top-ranking status with regard to hygiene, we would greatly appreciate your insights on ways in which the lowest-ranked participant, person B, could enhance their hygiene practices."));
        //rankQuestion.Add(new Question(Type.single, "person, do you like movies about gladiators?"));
        //rankQuestion.Add(new Question(Type.single, "Has person ever broken the law?"));


        //rankQuestion.Add(new Question(Type.rank, "Who is the best juggler?"));
        rankQuestion.Add(new Question(Type.rank, "Who has the highest pain threshold?"));
        rankQuestion.Add(new Question(Type.rank, "Who has the most knowledge in the fantasy genre of fiction?"));
        rankQuestion.Add(new Question(Type.rank, "Who is most interested in true-crime?"));
        rankQuestion.Add(new Question(Type.rank, "Who would enjoy being a mole for a day?"));
        rankQuestion.Add(new Question(Type.rank, "Is there anyone in the group that does not believe computers are conscious?"));




        currentQuestion = GetComponent<NameEntry>();
        currentQuestion.Rebuild("please enter your names", participants);
        namesComplete = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentQuestion.finished && namesComplete)
        {
            answers.Add(currentQuestion.GetAnswer());
            if (currentQuestion.GetAnswer().ranking != null)
            {
                foreach (string name in currentQuestion.GetAnswer().ranking)
                {
                    Debug.Log(name);
                }

            }
            switch (rankQuestion[qInd].type)
            {
                case Type.input:
                    currentQuestion = GetComponent<NameEntry>();
                    currentQuestion.Rebuild("enter your names", participants);
                    break;

                case Type.rank:
                    currentQuestion = GetComponent<RankQuestion>();
                    currentQuestion.Rebuild(rankQuestion[qInd].prompt, participants);
                    break;

                case Type.multi:

                    break;

                case Type.single:
                    currentQuestion = GetComponent<SingleOut>();
                    currentQuestion.Rebuild(rankQuestion[qInd].prompt, answers[1].ranking);
                    break;

            };
            qInd++;


        }

        else if (currentQuestion.finished)
        {
            participants = currentQuestion.GetAnswer().ranking;
        }

    }

}
