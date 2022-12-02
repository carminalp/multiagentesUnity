using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;  // Velocidad en unidades por segundo
    private float startTime;  // Tiempo inicial (cuando inicia el movimiento)
    private float journeyLenght; // Distacia total entre los marcadores
   
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; //Guarda la informacion del tiempo inicial
        journeyLenght = Vector3.Distance(startMarker.position,endMarker.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLenght;
        transform.position = Vector3.Lerp(startMarker.position,endMarker.position,fractionOfJourney);
    }

}
