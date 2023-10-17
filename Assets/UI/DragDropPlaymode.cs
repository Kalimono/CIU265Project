using UnityEditor;
using UnityEngine;
using Unity;
using UnityEngine.UIElements;

public class DragDropPlaymode : BaseQuestion
{
    UIDocument doc;

    public void Rebuild(string prompt)
    {
        doc = GetComponent<UIDocument>();
        doc.rootVisualElement.Clear();

        // Import UXML
        VisualElement root = doc.rootVisualElement;
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/DragDrop.uxml");
        var labelFromUXML = visualTree.Instantiate();


        VisualElement questionField = labelFromUXML.Q("questionField");
        TextElement question = new TextElement();
        question.text = prompt;
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, 50.0f);

        root.Add(labelFromUXML);

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/DragAndDropWindow.uss");

        for (int i = 0; i < 5; i++)
        {
            var txt = new TextElement();
            txt.style.color = new Color(0, 0, 0);
            txt.text = "name" + i.ToString();
            var ob = new VisualElement();
            ob.Add(txt);
            ob.AddToClassList("object");
            labelFromUXML.Add(ob);
            ob.transform.position = new Vector2(ob.transform.position.x, ob.transform.position.y + (55.0f * i));
            DragAndDropManipulator manip3 = new(ob);
        }

        
    }
}