using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
   public Transform target;
   public float speed;

  // Luz de los semáforos
   //public GameObject red;
   //public GameObject green;
   //public float timeRemaining = 10;
   //public float timeRemainingSemaforo = 10;

   float timeRemainingSemaforoBase;
 
   // Start is called before the first frame update
   //bool active = false;
   //bool avanza = false;
   void Start()
   {
        //red.SetActive(true);
        //green.SetActive(false);

        //float timeRemainingSemaforoBase = timeRemainingSemaforo;
   }
 
   // Update is called once per frame
   void Update()
   {
       float step=speed*Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position,target.position,step);
       // se agrega lo de si el semaforo esta activo
       /*if (timeRemainingSemaforoBase > 0) {
           timeRemainingSemaforoBase -= Time.deltaTime;
        } else {
            timeRemainingSemaforoBase = timeRemainingSemaforo;
            if (active) {
                active = false;
                red.SetActive(true);
                green.SetActive(false);
                speed = 0; 

            } else {
                active = true;
                red.SetActive(false);
                green.SetActive(true);
                speed = 5;
                transform.position = Vector3.MoveTowards(transform.position,target.position,step);
            }
        }*/
   }
}
