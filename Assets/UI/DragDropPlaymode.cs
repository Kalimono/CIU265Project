using UnityEditor;
using UnityEngine;
using Unity;
using UnityEngine.UIElements;

public class DragDropPlaymode : MonoBehaviour
{

    //private void 
    
    UIDocument doc;
    public void Start()
    {
        doc = GetComponent<UIDocument>();
        // Each editor window contains a root VisualElement object
        //VisualElement root = rootVisualElement;

        // Import UXML
        VisualElement root = doc.rootVisualElement;// AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/DropDownUXML.uxml");
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/DropDownUXML.uxml");
        var labelFromUXML = visualTree.Instantiate();


        VisualElement questionField = labelFromUXML.Q("questionField");
        //questionField.style.color = new Color(255, 0, 0);
        //VisualElement question = new TextElement();
        TextElement question = new TextElement();
        //question.style.color = new Color(0, 0, 0);
        question.text = "Put your names in order:\nCalmness in stressful sitiations.";
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, 50.0f);


        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/DragAndDropWindow.uss");

        //DragAndDropManipulator manipulator =
        //new(root.Q<VisualElement>("object"));
        for (int i = 0; i < 5; i++)
        {
            var txt = new TextElement();
            txt.style.color = new Color(0, 0, 0);
            txt.text = "name" + i.ToString();
            var ob = new VisualElement();
            ob.Add(txt);
            ob.AddToClassList("object");
            labelFromUXML.Add(ob);
            //questionField.Add(ob);
            ob.transform.position = new Vector2(ob.transform.position.x, ob.transform.position.y + (55.0f * i));
            //ob.transform.scale = new Vector3(1, 1.3f - (i * 0.1f), 1);
            DragAndDropManipulator manip3 = new(ob);

        }

    }
}