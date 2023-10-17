using UnityEditor;
using UnityEngine;
using Unity;
using System.Linq;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;


public class SingleOut : BaseQuestion
{
    UIDocument doc;
    List<VisualElement> draggables;

    public override void FinishQuestion(ClickEvent evt)
    {
        foreach (var ob in draggables)
        {
            if (ob.transform.position.x < 10)
                return;
        }
        this.finished = true;
    }

    public override Answer GetAnswer()
    {
        List<VisualElement> SortedList = draggables.OrderBy(o => o.transform.position.y).ToList();
        List<string> rankedNameList = SortedList.Select(o => o.Q<TextElement>().text).ToList();
        return new Answer(ranking: rankedNameList, choice: null);
    }


    public override void Rebuild(string prompt, List<string> names)
    {
        base.Rebuild(prompt, names);
        doc = GetComponent<UIDocument>();
        doc.rootVisualElement.Clear();

        // Import UXML
        VisualElement root = doc.rootVisualElement;
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/SingleOut/SingleOut.uxml");
        var labelFromUXML = visualTree.Instantiate();

        VisualElement questionField = labelFromUXML.Q("questionField");

        Button finishButton = new Button();
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);
        questionField.Add(finishButton);
        finishButton.transform.position = new Vector2(15.0f, 100.0f);

        TextElement question = new TextElement();
        question.text = prompt;
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, 50.0f);

        

        root.Add(labelFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/DragAndDropWindow.uss");
        
    }
}