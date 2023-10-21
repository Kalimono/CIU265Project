using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Unity;
using UnityEngine.UIElements;

public class NameEntry : BaseQuestion
{
    TextField textField;

    List<string> participants;

    public override void Rebuild(Question myQ)
    {
        base.Rebuild(myQ);
        participants = new List<string>();


        visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/NameEntry/NameEntry.uxml");
        labelFromUXML = visualTree.Instantiate();



        VisualElement questionField = labelFromUXML.Q("questionField");
        Image img = new Image();
        img.image = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/UI/powered.png");
        img.style.position = Position.Absolute;
        img.style.scale = new StyleScale(new Vector2(0.1f, 0.1f));
        //questionField.Add(img);
        //questionField.Add(powered);
        img.transform.position = new Vector2(400, 100);

        textField = labelFromUXML.Q<TextField>();
        VisualElement qf = questionField;
        TextElement question = new TextElement();
        question.text = myQ.prompt;
        questionField.Add(question);
        //question.transform.position = new Vector2(15.0f, -200.0f);

        Button myBtn = labelFromUXML.Q<Button>("enterName");
        myBtn.RegisterCallback<ClickEvent>(AddName);

        Button finishButton = labelFromUXML.Q<Button>("finish");
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);

        root.Add(labelFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/myStyle.uss");

    }

    private void AddName(ClickEvent evt)
    {
        if (textField.text.Length < 1) return;
        participants.Add(textField.text);
        string txt = textField.text;
        textField.SetValueWithoutNotify("");
        TextElement te = new TextElement();
        te.text = txt;
        VisualElement nf = root.Q("namefield");

        nf.Add(te);
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