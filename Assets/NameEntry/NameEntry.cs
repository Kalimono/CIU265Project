using UnityEditor;
using UnityEngine;
using Unity;
using UnityEngine.UIElements;

public class NameEntry : MonoBehaviour
{

    //private void 
    
    UIDocument doc;
    public void Rebuild()
    {
        doc = GetComponent<UIDocument>();
        doc.rootVisualElement.Clear();
        // Each editor window contains a root VisualElement object
        //VisualElement root = rootVisualElement;

        // Import UXML
        VisualElement root = doc.rootVisualElement;// AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/DropDownUXML.uxml");
        root.style.alignItems = Align.FlexEnd;
        root.style.flexDirection = FlexDirection.Row;
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/NameEntry/NameEntry.uxml");
        var labelFromUXML = visualTree.Instantiate();


        VisualElement questionField = labelFromUXML.Q("questionField");
        TextElement question = new TextElement();
        question.text = "Please enter your names";
        questionField.Add(question);
        question.transform.position = new Vector2(15.0f, 50.0f);


        root.Add(labelFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/DragAndDropWindow.uss");

        //DragAndDropManipulator manipulator =
        //new(root.Q<VisualElement>("object"));
        

    }
}