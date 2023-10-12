// using UnityEngine;
// using UnityEngine.UIElements;

// public class ButtonClickHandler : MonoBehaviour
// {
//     private VisualElement button;
//     private TextField textField;
//     private Slider slider;

//     private void Start()
//     {
//         // Find the button element by name
//         button = GetComponent<UIDocument>().rootVisualElement.Q("maxButton");
//         textField = GetComponent<UIDocument>().rootVisualElement.Q<TextField>("maxTF");
//         slider = GetComponent<UIDocument>().rootVisualElement.Q<Slider>("maxSlider");
//         // Attach a click event handler
//         button.RegisterCallback<ClickEvent>(OnClick);
//         textField.RegisterCallback<InputEvent>(OnTextFieldValueChanged);
//         slider.RegisterCallback<ChangeEvent<float>>(OnSliderValueChanged);
        
//     }

//     private void OnClick(ClickEvent evt)
//     {
//         Debug.Log("Button Clicked!");
//         // Add your custom logic here
//     }

//     private void OnTextFieldValueChanged(InputEvent evt)
//     {
//         // Access and print the text value of the TextField
//         string textFieldText = textField.value;
//         Debug.Log("TextField Value: " + textFieldText);

//         // You can perform actions based on the text value here
//     }

//     private void OnSliderValueChanged(ChangeEvent<float> evt)
//     {
//         // Access and print the text value of the TextField
//         float val = slider.value;
//         Debug.Log("Slider Value: " + val);

//         // You can perform actions based on the text value here
//     }
// }