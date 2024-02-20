using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;

public class JsonReader : MonoBehaviour
{
    public Text outputArea;
    public float updateInterval = 0.5f; // Update interval in seconds
    private Coroutine updateCoroutine;
    private string url = "https://sheets.googleapis.com/v4/spreadsheets/1PHaMEPnGlCu6vFdKLWi2sHjdCIcML3wY43Ym7P3YACo/values/Sheet1?key=AIzaSyBwXZvAl8_Yr5ZkJ0mwiYHbXQl1R92mdX0";

    // Start is called before the first frame update
    void Start()
    {
        updateCoroutine = StartCoroutine(UpdateJsonData());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UpdateJsonData() 
    {
         while (true)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                string updateText = "";
                string json = request.downloadHandler.text;

                var o = JSON.Parse(json);

                foreach (var item in o["values"])
                {
                    var itemo = JSON.Parse(item.ToString());
                    updateText = itemo[0][0];
                    // Debug.Log(updateText);
                }
                updateText = "Action Index: " + updateText;
                outputArea.text = updateText;
            }

            yield return new WaitForSeconds(updateInterval);
        }
    }

    void OnDestroy()
    {
        // Stop the coroutine when the object is destroyed
        if (updateCoroutine != null)
        {
            StopCoroutine(updateCoroutine);
        }
    }
}