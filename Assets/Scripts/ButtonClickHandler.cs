using UnityEngine;
using UnityEngine.UIElements;

public class DynamicUILayout : MonoBehaviour
{
    public VisualTreeAsset uiLayoutAsset;

    private void Start()
    {
        VisualElement uiRoot = new VisualElement();
        uiLayoutAsset.CloneTree(uiRoot);
        VisualElement background = uiRoot.Q<VisualElement>("background");

        // Create and configure the Label
        Label labelElement = new Label();
        labelElement.text = "Hello, World!";

        // Add the Label to the background before the Slider
        background.Add(labelElement);

        // Create and configure the Slider
        Slider sliderElement = new Slider();
        sliderElement.value = 0.5f;

        // Add the Slider to the background after the Label
        background.Add(sliderElement);

        //uiRoot.style.flexDirection = FlexDirection.Column;
        gameObject.GetComponent<UIDocument>().rootVisualElement.Add(uiRoot);
    }
}