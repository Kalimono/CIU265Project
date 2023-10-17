using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{


    List<string> participants;
    List<Question> rankQuestions;
    List<List<string>> rankings;
    List<Question> followUps;
    
     
    NameEntry name;
    DragDropPlaymode rank;
    public bool buildNameEntry;
    public bool buildRanking;

    int qInd;
    // Start is called before the first frame update
    void Start()
    {
        qInd = 0;
        name = GetComponent<NameEntry>();
        rank = GetComponent<DragDropPlaymode>();
        rankQuestions = new List<Question>();
        rankQuestions.Add(new Question(type: Type.rank, "test prompt"));

        name = GetComponent<NameEntry>();
        rank = GetComponent<DragDropPlaymode>();
        rank.Rebuild("a");
    }

    // Update is called once per frame
    void Update()
    {
        if (rank.finished)
        {
            rank.GetAnswer();
            qInd++;
            rank.Rebuild(rankQuestions[qInd].prompt);
        }
    }
}
