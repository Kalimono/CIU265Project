using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private VisualElement textBoxColumn;
    private TextField activeDraggedTextBox;
    private Vector2 offset;
    private Vector2 gridSize = new Vector2(100000f, 600f); // Adjust grid size as needed
    private Vector2 grabPoint = Vector2.zero;

    void Start()
    {
        // Create a new VisualTree
        VisualTreeAsset visualTreeAsset = Resources.Load<VisualTreeAsset>("UXML/BlankVisualTree");
        VisualElement root = visualTreeAsset.CloneTree();

        // Set the background color to white
        root.style.backgroundColor = Color.white;

        // Create a column for drag-and-drop text boxes
        textBoxColumn = new VisualElement();
        textBoxColumn.style.flexDirection = FlexDirection.Column;
       
        root.Add(textBoxColumn);

        // Create and add drag-and-drop text boxes
        for (int i = 1; i <= 5; i++)
        {
            TextField textBox = new TextField();
            textBox.RegisterCallback<PointerDownEvent>((evt) =>
            {
                if ( evt.button == 0)
                {
                    return;
                }
                Debug.Log("Grabbing");
                var mousePosition = Mouse.current.position.ReadValue();
                grabPoint = mousePosition;
                Debug.Log(grabPoint);
                // Mouse down on a text box; initiate drag
                activeDraggedTextBox = textBox;
                activeDraggedTextBox.CapturePointer(evt.pointerId);

                // Calculate the offset from the mouse cursor to the text box's position
                offset = evt.localPosition;
            });

            textBox.RegisterCallback<PointerUpEvent>((evt) =>
            {
                
                
                if (activeDraggedTextBox != null)
                {
                    grabPoint = Vector2.zero;
                    Debug.Log("Releasing");
                    // Mouse up; end drag
                    activeDraggedTextBox.ReleasePointer(evt.pointerId);

                    // Snap to the nearest grid position
                    SnapToGrid(activeDraggedTextBox);

                    activeDraggedTextBox = null;
                }
            });
            textBox.style.width = 500;
            textBoxColumn.Add(textBox);
        }

        // Attach the VisualTree to the UI hierarchy
        var uiDocument = GetComponent<UIDocument>();
        var panel = uiDocument.rootVisualElement;
        panel.Add(root);
    }

    private void Update()
    {
        if (activeDraggedTextBox != null)
        {
            // While dragging, update the text box's position
            var mousePosition = Mouse.current.position.ReadValue();

            activeDraggedTextBox.style.left = mousePosition.x - grabPoint.x;
            activeDraggedTextBox.style.top = -mousePosition.y + grabPoint.y; // Invert vertical movement
        }
    }

    private void SnapToGrid(TextField textBox)
    {
        // Calculate the closest grid position
        float x = Mathf.Round(textBox.resolvedStyle.left / gridSize.x) * gridSize.x;
        float y = Mathf.Round(textBox.resolvedStyle.top / gridSize.y) * gridSize.y;

        // Calculate the actual offset from the mouse cursor to the new position
        float xOffset = x - textBox.resolvedStyle.left;
        float yOffset = y - textBox.resolvedStyle.top;

        // Apply the snap position with the corrected offset
        textBox.style.left = x;
        textBox.style.top = y;

        // Update the offset for future adjustments
        offset = new Vector2(offset.x + xOffset, offset.y + yOffset);
    }
}