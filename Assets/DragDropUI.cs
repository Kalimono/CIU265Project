using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragDropUI : MonoBehaviour
{
    public UIDocument UIDocument;
    public VisualTreeAsset redTree;
    public VisualTreeAsset greeTree;
    public VisualTreeAsset rankTree;
    VisualElement root;
    // Start is called before the first frame update
    void Start()
    {
        UIDocument = GetComponent<UIDocument>();
        root = UIDocument.rootVisualElement.Q("root");

        VisualElement redScreen = redTree.CloneTree();
        redScreen.Q<VisualElement>("red").Add(new Button());
        redScreen.style.height = 100;
        root.Add(redScreen);
        
        VisualElement greenScreen = greeTree.CloneTree();
        greenScreen.Q<VisualElement>("green").Add(new Button());
        greenScreen.style.height = 200;
        root.Add(greenScreen);

        VisualElement rankWindow = rankTree.CloneTree().Q<VisualElement>("RankWindow");
        rankWindow.style.height = 600;
        rankWindow.Add(new Button());
        
        for (int i = 0; i < 5; i++)
        {
            
            rankWindow.Add(_nameBox());
        }
        root.Add(rankWindow);

    }
    private Vector2 mouseD;
    // Update is called once per frame
    void Update()
    {
        if (currentlyDragged == null) return;
        Vector2 mousePos = Input.mousePosition;

        currentlyDragged.style.left = mousePos.x - 400;
        currentlyDragged.style.top = -mousePos.y + 230;
    }

    Label currentlyDragged;
    Vector2 posInside;
    private Label _nameBox()
    {
        Label nameBox = new Label();
        nameBox.style.unityTextAlign = TextAnchor.MiddleCenter;
        nameBox.text = "NAme";
        nameBox.style.backgroundColor = Color.white;

        nameBox.RegisterCallback<PointerDownEvent>((evt) =>
        {
            if (evt.button == 0) { return; }
            mouseD = evt.deltaPosition;
            currentlyDragged = nameBox;

        });
        nameBox.RegisterCallback<PointerUpEvent>((evt) =>
        {
            Debug.Log("REleased");
            if (currentlyDragged == nameBox)
            {
                currentlyDragged = null;
            };
        });
        return nameBox;
    }
}
