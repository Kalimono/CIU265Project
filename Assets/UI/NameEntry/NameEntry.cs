using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Unity;
using UnityEngine.UIElements;

public class NameEntry : BaseQuestion
{
    UIDocument doc;
    string txt;
    VisualElement qf;

    List<string> participants;

    public override void Rebuild(string prompt, List<string> names, bool? first)
    {
        Debug.Log("Built");
        doc = GetComponent<UIDocument>();
        doc.rootVisualElement.Clear();
        // Each editor window contains a root VisualElement object
        //VisualElement root = rootVisualElement;

        // Import UXML
        VisualElement root = doc.rootVisualElement;// AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/DropDownUXML.uxml");
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;


        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/NameEntry/NameEntry.uxml");
        var labelFromUXML = visualTree.Instantiate();


        VisualElement questionField = labelFromUXML.Q("questionField");
        qf = questionField;
        TextElement question = new TextElement();
        question.text = prompt;
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, 50.0f);

        txt = question.text;

        Button myBtn = labelFromUXML.Q<Button>("enterName");
        myBtn.RegisterCallback<ClickEvent>(FinishQuestion);

        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/DragAndDropWindow.uss");        

    }

    public override void FinishQuestion(ClickEvent evt)
    {   
        participants.Add("");
        Debug.Log("FINISH");
        if (participants.Count >= 3) {
            finished = true;
        }
    }

    public override Answer GetAnswer()
    {
        return new Answer(participants, null);
    }

}