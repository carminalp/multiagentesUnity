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

    List<List<Vector3> > positions;

    [System.Serializable]
    public class Car
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
    }

    private readonly string baseAPIURL = "http://localhost:8585";

    //Get Car and Traffic Info
    IEnumerator GetCarAtIndex()
    {
        //Info del carro
        string carURL = baseAPIURL + "/car";

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
        }










        /*
        JSONNode carInfo = Info[];
        for(int k=0; k<carInfo.Count ; k++){
            List<Vector3> newPositions = new List<Vector3>();
            Instantiate(PrefabCarro, new Vector3(-20*k,-10,0), Quaternion.identity);
            for(int i=0; i<carInfo.Count ; i++){
                int x = carInfo[i.ToString()]["x"];
                int y = carInfo[i.ToString()]["y"];
                int z = carInfo[i.ToString()]["z"];
                Vector3 auxV = new Vector3(x, y, z);
                newPositions.Add(auxV);
            }
            positions.Add(newPositions);
        }
        */

        /*
        int[][] jaggedArray = new int[Info.Count][];

        for(int k=0; k<Info.Count ; k++){


            JSONNode carInfo = Info[k.ToString()];
            int[] carMoveX = new int[carInfo.Count];
            int[] carMoveY = new int[carInfo.Count];
            int[] carMoveZ = new int[carInfo.Count];

            for (int i = 0, j = carInfo.Count - 1; i < carInfo.Count; i++, j--)
            {
                carMoveX[j] = carInfo[i.ToString()]["x"];
                carMoveY[j] = carInfo[i.ToString()]["y"];
                carMoveZ[j] = carInfo[i.ToString()]["z"];
            }

            //jaggedArray[k] = new int[1] carMoveX;

        }
        */
        
        /*
        for(int i=0; i<Info.Count ; i++){
            JSONNode carInfo = Info[i.ToString()];
            Instantiate(PrefabCarro, new Vector3(-20*i,-10,0), Quaternion.identity);
            for(int j=1; j<carInfo.Count ; j++){
                JSONNode stepInfo = carInfo[i][j.ToString()];
                for(int k=0; k<stepInfo.Count ; k++){
                    int carX = stepInfo[j]["x"];
                    int carY = stepInfo[j]["y"];
                    int carZ = stepInfo[j]["z"];
                    

                    if(j==1){
                        PrefabCarro.transform.position = new Vector3(carX*4, carY*4, carZ*4);
                    }else if(j!=1){
                        PrefabCarro.transform.position = Vector3.MoveTowards(transform.position,new Vector3(carX*4, carY*4, carZ*4),10);
                    }
                }

            }
        }
        */
        
        /*Info del Trafficlight
        string trafficURL = baseAPIURL + "/trafficLight";

        UnityWebRequest trafficInfoRequest = UnityWebRequest.Get(trafficURL);

        yield return trafficInfoRequest.SendWebRequest();

        if (trafficInfoRequest.isNetworkError || trafficInfoRequest.isHttpError)
        {
            Debug.LogError(trafficInfoRequest.error);
            yield break;
        }

        JSONNode trafficInfo = JSON.Parse(trafficInfoRequest.downloadHandler.text);
        */ 
    }


    void Start()
    {
        StartCoroutine(GetCarAtIndex());
    }
    void Update()
    {

    }
}
