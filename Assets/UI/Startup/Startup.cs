using UnityEditor;
using UnityEngine;
using Unity;
using System.Linq;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Startup : BaseScreen
{
    //UIDocument doc;

    public override void FinishQuestion(ClickEvent evt)
    {
        finished = true;
    }

    public override Answer GetAnswer()
    {
        return base.GetAnswer();
    }


    public override void Rebuild(Question myQ)
    {
        base.Rebuild(myQ);

        visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/Startup/Startup.uxml");
        labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

        Button finishButton = labelFromUXML.Q<Button>();
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/myStyle.uss");
        


        
    }


}