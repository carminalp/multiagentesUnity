using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.Text;
using System;

public class ApiController : MonoBehaviour
{
    public GameObject PrefabCarro;
    public trafficLight light0, light1, light2, light3;

    /*public class Car
    {
        public int id;
        public int posX;
        public int posY;
        public int posZ;
        public int dir;
        public int step;
    }

    [System.Serializable]
    public class CarList
    {
        public Car[] car;
    }*/


    [System.Serializable]
    public class TrafficL
    {
        public int id { get; set; }
        public bool state { get; set; }
        public int step { get; set; }
    }

    [System.Serializable]
    public class TrafficList
    {
        //public TrafficL[] traffic;
        public TrafficL[] traffic { get; set; }
    }

    public TrafficList trafficList = new TrafficList();

    private readonly string baseAPIURL = "http://localhost:8585";

    //Get Car and Traffic Info
    IEnumerator getAPI()
    {
        //Info del carro
        /*string carURL = baseAPIURL + "/car";

        UnityWebRequest carInfoRequest = UnityWebRequest.Get(carURL);

        yield return carInfoRequest.SendWebRequest();

        if (carInfoRequest.isNetworkError || carInfoRequest.isHttpError)
        {
            Debug.LogError(carInfoRequest.error);
            yield break;
        }

        JSONNode Info = JSON.Parse(carInfoRequest.downloadHandler.text);

        for(int i=0; i<Info.Count ; i++){
            Instantiate(PrefabCarro, new Vector3(-20*i,-10,0), Quaternion.identity);
            List<Vector3> newPositions = new List<Vector3>();
            for(int j=1; j<Info[i.ToString()].Count ; j++){
                int carX = Info[i.ToString()][j.ToString()]["x"];
                int carY = Info[i.ToString()][j.ToString()]["y"];
                int carZ = Info[i.ToString()][j.ToString()]["z"];
                Vector3 auxV = new Vector3(carX, carY, carZ);
                Debug.Log(auxV);
                newPositions.Add(auxV);
            }
            positions.Add(newPositions);
        }*/

        //Info del semaforo
        
        string trafficLightURL = baseAPIURL + "/trafficLight";
        
        UnityWebRequest trafficLightRequest = UnityWebRequest.Get(trafficLightURL);
        
        yield return trafficLightRequest.SendWebRequest();

        if (trafficLightRequest.isNetworkError || trafficLightRequest.isHttpError)
        {
            Debug.LogError(trafficLightRequest.error);
            yield break;
        }
        //JSONNode Info = JSON.Parse(trafficLightRequest.downloadHandler.text);
        string Info = trafficLightRequest.downloadHandler.text;
         
        //trafficList = JsonUtility.FromJson<TrafficList>(Info);
        trafficList = JsonConvert.DeserializeObject<TrafficList>(Info);
        Debug.Log(trafficList);  

        TrafficL[] trafficL = trafficList.traffic; 
        //Debug.Log(trafficL[1].id); 

        for(int i = 0; i < trafficL.Length; i++)
        {
             
            /*int unique_id = trafficL[i].id;
            Debug.Log(trafficL[i].id);  
            bool state = trafficL[i].state;
            
            Debug.Log(state);

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
            }*/
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


