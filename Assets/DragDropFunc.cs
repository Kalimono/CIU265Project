using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragDropFunc : MonoBehaviour
{
    public VisualTreeAsset DNDTree;
    // Start is called before the first frame update
    void Start()
    {
        VisualElement DndWin = DNDTree.CloneTree().Q<VisualElement>("RankWindow");

        DndWin.Add(new Button());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
