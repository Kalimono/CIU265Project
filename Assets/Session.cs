using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{


    List<string> participants;
    List<Question> rankQuestions;
    List<List<string>> rankings;
    List<Question> followUps;
    List<Answer> answers;
    
     
    NameEntry name;
    BaseQuestion currentQuestion;
    public bool buildNameEntry;
    public bool buildRanking;

    int qInd;
    // Start is called before the first frame update
    void Start()
    {
        participants = new List<string>();
        participants.Add("Heinrich");
        participants.Add("Job");
        participants.Add("Greger");
        participants.Add("Majken");
        participants.Add("Hjulia");

        //name = GetComponent<NameEntry>();
        rankQuestions = new List<Question>();
        //rankQuestions.Add(new Question(type: Type.input, "test prompt1"));
        rankQuestions.Add(new Question(type: Type.rank, "test prompt1"));
        rankQuestions.Add(new Question(type: Type.rank, "test prompt2"));
        rankQuestions.Add(new Question(type: Type.rank, "test prompt3"));

        ////name = GetComponent<NameEntry>();
        //currentQuestion = GetComponent<NameEntry>();
        //currentQuestion.Rebuild("a", participants);
        currentQuestion = GetComponent<NameEntry>();
        currentQuestion.Rebuild("enter names", participants);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentQuestion.finished)
        {   
            switch (rankQuestions[qInd].type)
            {
                case Type.input:
                    currentQuestion = GetComponent<NameEntry>();
                    currentQuestion.Rebuild("enter your names", participants);
                    break;

                case Type.rank:
                    Debug.Log("Yes");
                    currentQuestion = GetComponent<RankQuestion>();
                    Debug.Log(currentQuestion);
                    currentQuestion.Rebuild(rankQuestions[qInd].prompt, participants);
                    //currentQuestion.finished = false;
                    break;

                case Type.multi:

                    break;

                case Type.single:

                    break;

            };
            qInd++;


        }
    }
}
