using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;

public class ApiController : MonoBehaviour
{
    public GameObject PrefabCarro;
    public trafficLight light0, light1, light2, light3;
    private readonly string baseAPIURL = "http://localhost:8585";
    struct Traffic
    {
        public int id;
        public bool state;
        public int step;
        public Traffic(int id, bool state, int step)
        {
            this.id = id;
            this.state = state;
            this.step = step;
        }
    }
    Traffic[] trafficLightData;
    IEnumerator getAPI()
    {        
        string trafficLightURL = baseAPIURL + "/trafficLight";
        
        UnityWebRequest trafficLightRequest = UnityWebRequest.Get(trafficLightURL);
        
        yield return trafficLightRequest.SendWebRequest();

        if (trafficLightRequest.isNetworkError || trafficLightRequest.isHttpError)
        {
            Debug.LogError(trafficLightRequest.error);
            yield break;
        }
        
        JSONNode InfoTL = JSON.Parse(trafficLightRequest.downloadHandler.text);
        JSONNode trafficLight = InfoTL["trafficL"];
        //Debug.Log(trafficLight);
        
        trafficLightData = new Traffic[trafficLight.Count];

        //int sizeTraffic = trafficLight.Count;
        
        for (int i = 0; i < trafficLight.Count; i++)
        {
            trafficLightData[i].id = trafficLight[i]["id"];
            trafficLightData[i].state = trafficLight[i]["state"];
            trafficLightData[i].step = trafficLight[i]["step"];
        }
        
        /*Debug.Log(trafficLightData[20].id);
        Debug.Log(trafficLightData[20].state);
        Debug.Log(trafficLightData[20].step);*/

        for(int i = 0; i < trafficLightData.Length; i++)
        {
            int unique_id = trafficLightData[i].id;
            bool state = trafficLightData[i].state;
            
            if(unique_id == 0)
            {
                light0.states.Add(state);
            }

            else if(unique_id == 1)
            {
                light1.states.Add(state);
            }

            else if (unique_id == 2)
            {
                light2.states.Add(state);
            }

            else if (unique_id == 3)
            {
                light3.states.Add(state);
            }
        }
        
    }


    void Start()
    {
        StartCoroutine(getAPI());
    }
    void Update()
    {

    }
}