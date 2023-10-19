using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Unity;
using UnityEngine.UIElements;

public class NameEntry : BaseQuestion
{
    UIDocument doc;
    //string txt;
    VisualElement qf;
    TextField textField;

    List<string> participants;

    public override void Rebuild(Question myQ)
    {
        base.Rebuild(myQ);
        participants = new List<string>();
        doc = GetComponent<UIDocument>();
        doc.rootVisualElement.Clear();
        // Each editor window contains a root VisualElement object
        //VisualElement root = rootVisualElement;

        // Import UXML
        VisualElement root = doc.rootVisualElement;
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;


        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/NameEntry/NameEntry.uxml");
        var labelFromUXML = visualTree.Instantiate();


        VisualElement questionField = labelFromUXML.Q("questionField");
        textField = labelFromUXML.Q<TextField>();
        qf = questionField;
        TextElement question = new TextElement();
        question.text = myQ.prompt;
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, -200.0f);

        Button myBtn = labelFromUXML.Q<Button>("enterName");
        myBtn.RegisterCallback<ClickEvent>(AddName);

        Button finishButton = labelFromUXML.Q<Button>("finish");
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);

        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/DragAndDropWindow.uss");        

    }

    private void AddName(ClickEvent evt)
    {
        if (textField.text.Length < 1) return;
        participants.Add(textField.text);
        Debug.Log(participants.Count);
        Debug.Log(participants[0]);
        string txt = textField.text;
        textField.SetValueWithoutNotify("");
        TextElement te = new TextElement();
        te.text = txt;
        
        qf.Add(te);
    }

    public override void FinishQuestion(ClickEvent evt)
    {   
        if (participants.Count >= 3) {
            finished = true;
        }
    }

    public override Answer GetAnswer()
    {
        return new Answer(participants, null);
    }

}