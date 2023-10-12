
    // // Start is called before the first frame update
    // using UnityEngine;
    // using UnityEngine.UIElements;

    // public class UIManager : MonoBehaviour
    // {   
    //     // [SerializeField]
    //     VisualElement root;

    //     void Start()
    //     {
    //         // Create a new VisualElement root
    //         root = new VisualElement();

    //         // Load the UXML file and clone its hierarchy into the root VisualElement
    //         var visualTree = GetComponent<UIDocument>().rootVisualElement; //Resources.Load<VisualTreeAsset>("UIElementSample");
    //         // visualTree.CloneTree(root);

    //         // Get references to UI elements in the hierarchy
    //         var label = root.Q<Label>("myLabel");
    //         var textField = root.Q<TextField>("myTextField");
    //         var button = root.Q<Button>("myButton");

    //         // Add a click event listener to the button
    //         button.clickable.clicked += () =>
    //         {
    //             // When the button is clicked, update the label text with the content of the text field
    //             label.text = "Hello, " + textField.value;
    //         };

    //         // Add the root VisualElement to the UI hierarchy
    //         var panel = GetComponent<UIDocument>().rootVisualElement;
    //         panel.Add(root);

    //         root.style.display = DisplayStyle.Flex;
    //     }
    // }

