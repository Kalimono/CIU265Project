using UnityEditor;
using UnityEngine;
using Unity;
using System.Linq;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Startup : BaseQuestion
{
    UIDocument doc;

    public override void FinishQuestion(ClickEvent evt)
    {
        finished = true;
    }

    public override Answer GetAnswer()
    {
        return base.GetAnswer();
    }


    public override void Rebuild(string prompt, List<string> names, bool? first)
    {
        base.Rebuild(prompt, names, null);
        doc = GetComponent<UIDocument>();
        doc.rootVisualElement.Clear();

        // Import UXML
        VisualElement root = doc.rootVisualElement;
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/Startup/Startup.uxml");
        var labelFromUXML = visualTree.Instantiate();

        VisualElement questionField = labelFromUXML.Q("root");

        Button finishButton = new Button();
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);
        questionField.Add(finishButton);
        //finishButton.transform.position = new Vector2(15.0f, 100.0f);

        TextElement question = new TextElement();
        question.text = prompt;
        questionField.Add(question);
        //question.transform.position = new Vector2(15.0f, 0.0f);

        

        root.Add(labelFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/Startup/Startup.uss");
        
    }


}