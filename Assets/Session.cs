using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session : MonoBehaviour
{
    NameEntry name;
    DragDropPlaymode rank;
    public bool buildNameEntry;
    public bool buildRanking;
    // Start is called before the first frame update
    void Start()
    {
        name = GetComponent<NameEntry>();
        rank = GetComponent<DragDropPlaymode>();
        //dd.Build();
    }

    // Update is called once per frame
    void Update()
    {
        if (buildRanking)
        {
            buildRanking = false;
            rank.Rebuild();
        }

        if (buildNameEntry)
        {
            buildNameEntry = false;
            name.Rebuild();
        }
    }
}
