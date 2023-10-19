using UnityEditor;
using UnityEngine;
using Unity;
using System.Linq;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class SingleOut : BaseQuestion
{
    UIDocument doc;
    List<VisualElement> draggables;

    public override void FinishQuestion(ClickEvent evt)
    {
        finished = true;
    }

    public override Answer GetAnswer()
    {
        List<VisualElement> SortedList = draggables.OrderBy(o => o.transform.position.y).ToList();
        List<string> rankedNameList = SortedList.Select(o => o.Q<TextElement>().text).ToList();
        return new Answer(ranking: rankedNameList, choice: null);
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
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/SingleOut/SingleOut.uxml");
        var labelFromUXML = visualTree.Instantiate();

        VisualElement questionField = labelFromUXML.Q("questionField");

        Button finishButton = new Button();
        finishButton.RegisterCallback<ClickEvent>(FinishQuestion);
        questionField.Add(finishButton);
        finishButton.transform.position = new Vector2(15.0f, 100.0f);

        TextElement question = new TextElement();
        question.text = ReplacePlaceholders(prompt, names);
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, 0.0f);

        

        root.Add(labelFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/DragAndDropWindow.uss");
        
    }


    static string ReplacePlaceholders(string input, List<string> replacementStrings)
    {
        if (replacementStrings.Count < 2)
        {
            return "SOMETHING WENT WRONG";
        }

        string firstReplacement = replacementStrings[0];
        string lastReplacement = replacementStrings[replacementStrings.Count - 1];

        StringBuilder result = new StringBuilder();
        int index = 0;

        while (index < input.Length)
        {
            if (input[index] == '!' && index + 7 < input.Length &&
                input.Substring(index, 7) == "!PFIRST")
            {
                result.Append(firstReplacement);
                index += 7;
            }
            else if (input[index] == '!' && index + 6 < input.Length &&
                     input.Substring(index, 6) == "!PLAST")
            {
                result.Append(lastReplacement);
                index += 6;
            }
            else
            {
                result.Append(input[index]);
                index++;
            }
        }

        return result.ToString();
    }

}