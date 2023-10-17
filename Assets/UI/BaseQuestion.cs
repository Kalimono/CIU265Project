using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseQuestion : MonoBehaviour
{
    public bool finished;
    List<string>? ranking;
    List<string>? choice;

    public virtual Answer GetAnswer()
    {
        return new Answer(ranking, choice);
    }

    public abstract void FinishQuestion(ClickEvent evt);


    public virtual void Rebuild(string prompt, List<string> names)
    {
        finished = false;
    }


}
