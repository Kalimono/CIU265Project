using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ArduinoEvent
{
    public void PerformEvent();
}

public class Shake : ArduinoEvent
{
    public void PerformEvent()
    {
        Debug.Log("Sent to arduino");
    }
}
