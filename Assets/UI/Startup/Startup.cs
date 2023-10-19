using UnityEditor;
using UnityEngine;
using Unity;
using System.Linq;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;


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

        VisualElement startupField = labelFromUXML.Q("startupScreen");

        Button finishButton = new Button();
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);
        startupField.Add(finishButton);
        //finishButton.transform.position = new Vector2(15.0f, 100.0f);

        TextElement introText = new TextElement();
        introText.text = prompt;
        startupField.Add(introText);
        //introText.transform.position = new Vector2(15.0f, 0.0f);

        

        root.Add(labelFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/Startup/Startup.uss");
        
    }
}