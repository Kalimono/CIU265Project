using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseQuestion : MonoBehaviour
{
    public bool finished;
    List<string>? ranking;
    List<string>? choice;

    public virtual Answer GetAnswer()
    {
        return new Answer(ranking, choice);
    }


}
