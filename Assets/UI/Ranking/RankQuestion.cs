using UnityEditor;
using UnityEngine;
using Unity;
using System.Linq;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;


public class RankQuestion : BaseQuestion
{
    
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


    public override void Rebuild(Question myQ)
    {
        base.Rebuild(myQ);
        
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;
        visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/Ranking/DragDrop.uxml");
        labelFromUXML = visualTree.Instantiate();

        VisualElement questionField = labelFromUXML.Q("questionField");

        Button finishButton = new Button();
        finishButton.AddToClassList("continue");
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);
        questionField.Add(finishButton);
        finishButton.transform.position = new Vector2(15.0f, 200.0f);

        TextElement question = new TextElement();
        question.text = myQ.prompt;
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, 50.0f);

        

        root.Add(labelFromUXML);

        //var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/myStyle.uss");


        draggables = new List<VisualElement>();
        for (int i = 0; i < myQ.orderedNames.Count; i++)
        {
            var txt = new TextElement();
            txt.style.color = new Color(0, 0, 0);
            txt.text = myQ.orderedNames[i];
            var ob = new VisualElement();
            ob.Add(txt);
            ob.AddToClassList("object");
            labelFromUXML.Add(ob);
            ob.transform.position = new Vector2(ob.transform.position.x, ob.transform.position.y + (55.0f * i));
            DragAndDropManipulator manip3 = new(ob);
            draggables.Add(ob);
        }

        
        
    }
}