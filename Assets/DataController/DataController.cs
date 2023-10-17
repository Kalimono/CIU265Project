using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    List<Participant> participants = new List<Participant>();
    List<DragAndDropAnswer> dragAndDropAnswers = new List<DragAndDropAnswer>();
    List<QuestionsAnswer> questionsAnswers = new List<QuestionsAnswer>();
    
    void addParticipant(string name, int age)
    {
        participants.Add(new Participant(name, age));
    }

    void addDragAndDropAnswer(List<Participant> participants)
    {
        dragAndDropAnswers.Add(new DragAndDropAnswer(participants));
    }

    void addQuestionsAnswer(string answer)
    {
        questionsAnswers.Add(new QuestionsAnswer(answer));
    }
}
