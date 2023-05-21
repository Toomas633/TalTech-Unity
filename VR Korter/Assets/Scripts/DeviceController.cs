using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class DeviceController : MonoBehaviour
{
    [Header("Server filed.")]
    public ServerSettings server;
    public KeyCode toggleKey = KeyCode.Space;
    public bool useDatabaseData = true;
    private bool useDatabaseHelper = false;


    [Header("Device settings")]
    public int deviceID;
    public string deviceName;
    public bool deviceState = false;

    public UnityEvent activateSomething = new UnityEvent();
    public UnityEvent deactivateSomething = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetData(deviceName));
    }

    // Update is called once per frame
    void Update()
    {
        if(deviceState)
        {
           activateSomething.Invoke();

        }
        else
        {
          deactivateSomething.Invoke();
        }
        if(useDatabaseData && !useDatabaseHelper)
        {
          useDatabaseHelper = true;
          StartCoroutine(GetData(deviceName));
        }
        if(!useDatabaseData && useDatabaseHelper)
        {
          useDatabaseHelper = false;
          StopCoroutine(GetData(deviceName));
        }

        if(Input.GetKeyDown(toggleKey))
        {
          if(deviceState)
          {
              StateOff();
          }
          if(!deviceState)
          {
              StateOn();
          }

        }
    }

    public void StateOn()
    {
        StartCoroutine(UpdateDeviceSate(1, deviceName));
    }
    public void StateOff()
    {
        StartCoroutine(UpdateDeviceSate(0, deviceName));
    }

    IEnumerator GetData(string deviceName)
    {
        while(useDatabaseData)
        {
          WWWForm form = new WWWForm();
          form.AddField("deviceName", deviceName);

          using (UnityWebRequest www = UnityWebRequest.Post("http://"+server.serverIP+"/GetData.php", form))
          {
            yield return www.SendWebRequest();

            int _state = int.Parse(www.downloadHandler.text);
            //Debug.Log(_state);
            if(_state == 0)
            {
              deviceState = false;
            }
            if(_state == 1)
            {
              deviceState = true;
            }
            //yield return new WaitForSecondsRealtime(0.35f);
          }
        }

    }

    IEnumerator UpdateDeviceSate(int deviceStateUpdate, string deviceName)
    {
        WWWForm form = new WWWForm();
        form.AddField("deviceState", deviceStateUpdate);
        form.AddField("deviceName", deviceName);

        using(UnityWebRequest www = UnityWebRequest.Post("http://"+server.serverIP+"/UpdateState.php", form))
        {
          yield return www.SendWebRequest();

          if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
