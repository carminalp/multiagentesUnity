using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject[] waypoints; // Hacemos una lista que almacena todas las posiciones de los waypoints
    //private Transform targetWaypoint; // El waypoint al que nos moveremos
    private int currentWaypointIndex = 0; // Indice de waypoint, indica la posicion del waypoint en el arreglo
    public float speed = 10.0F; // Velocidad a la que se mueve

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWaypointIndex].transform.position) < 3){
            currentWaypointIndex++;
        }

        if (currentWaypointIndex >= waypoints.Length){
            Destroy(gameObject);
        }

        this.transform.LookAt(waypoints[currentWaypointIndex].transform);
        this.transform.Translate(0,0, speed * Time.deltaTime);
    }

}
