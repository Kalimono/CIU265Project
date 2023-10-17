using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    NameEntry name;
    DragDropPlaymode rank;
    QuestionPhase question;

    public bool buildNameEntry;
    public bool buildRanking;
    public bool buildQuestionPhase;
    // Start is called before the first frame update
    void Start()
    {
        name = GetComponent<NameEntry>();
        rank = GetComponent<DragDropPlaymode>();
        question = GetComponent<QuestionPhase>();
        //dd.Build();
        Debug.Log(question);
    }

    // Update is called once per frame
    void Update()
    {
        if (buildRanking)
        {
            buildRanking = false;
            rank.Rebuild();
        }

        if (buildNameEntry)
        {
            buildNameEntry = false;
            name.Rebuild();
        }

        if (buildQuestionPhase)
        {
            buildQuestionPhase = false;
            question.Rebuild();
        }
    }
}
