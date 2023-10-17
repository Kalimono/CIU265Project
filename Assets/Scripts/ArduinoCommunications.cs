using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DataSender : MonoBehaviour
{
    private string serverURL = "http://localhost:5000/write"; // Replace with your Flask server URL

    private int currentAngle = 90;

    void Start()
    {
        StartCoroutine(SendDataToServer(currentAngle));
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     StartCoroutine(SendDataToServer(currentAngle));
        // }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentAngle > 0)
            {
                currentAngle -= 10;
            } else {
                currentAngle = 0;
            }

            StartCoroutine(SendDataToServer(currentAngle));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentAngle < 180)
            {
                currentAngle += 10;
            } else {
                currentAngle = 180;
            }

            StartCoroutine(SendDataToServer(currentAngle));
        }
    }

    IEnumerator SendDataToServer(int currentAngle)
    {   
        Debug.Log("Sending data to server...");
        // Create a POST request
        UnityWebRequest request = new UnityWebRequest(serverURL, "POST");
        request.SetRequestHeader("Content-Type", "application/json");

        // Create JSON data to send (replace with your data)
        string jsonData = "{\"angle\": " + currentAngle + "}";  

        // Convert JSON data to a byte array
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);

        // Attach the data to the request
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);

        // Send the request
        yield return request.SendWebRequest();

        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.DataProcessingError))
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Data sent successfully.");
        }
    }
}
