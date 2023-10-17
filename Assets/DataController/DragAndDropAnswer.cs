using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropAnswer : MonoBehaviour
{
    public List<Participant> participantsOrder = new List<Participant>();

    public DragAndDropAnswer(List<Participant> participants)
    {
        participantsOrder = participants;
}
}
