using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerSettings : MonoBehaviour
{
    public string serverIP;



    void Start()
    {
        string uri = "Http://"+serverIP;

        if(serverIP.Length != 0)
        {
            StartCoroutine(GetRequest(uri));
        }
        else
        {
            Debug.Log("Server IP filed is empty");
        }

    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string resultText;

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                resultText = webRequest.error;
            }
            else
            {
                resultText = "Connection successful.";
            }

            Debug.Log(resultText);
        }
    }
}
