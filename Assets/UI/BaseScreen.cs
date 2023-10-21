using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

#nullable enable
public abstract class BaseScreen : MonoBehaviour
{
    public Question? MyQ;
    public bool finished;
    protected List<string>? ranking;
    protected List<string>? choice;
    protected Label? errorLabel;
    protected UIDocument? doc;
    protected VisualElement? root;
    protected VisualElement? labelFromUXML;
    protected VisualTreeAsset? visualTree;

    public virtual Answer GetAnswer()
    {
        return new Answer(ranking, choice);
    }

    public abstract void FinishQuestion(ClickEvent evt);


    public virtual void Rebuild(Question myQ)
    {
        MyQ = myQ;
        finished = false;

        doc = GetComponent<UIDocument>();
        doc.rootVisualElement.Clear();
        root = doc.rootVisualElement;

        errorLabel = new Label();
        errorLabel.style.position = Position.Absolute;
        errorLabel.transform.position = Vector2.zero;
        errorLabel.text = " all is good ";

    }


}
