using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLight : MonoBehaviour
{
    public GameObject red;
   public GameObject green;

   public int unique_id;
   public bool state = false;
   public List<bool> states;

   public int lightCount = 0; // recordar si funciona con -1 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeColor",0.2f,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (state) {
           red.SetActive(false);
           green.SetActive(true);

        } else {
            red.SetActive(true);
            green.SetActive(false);
        }
    }

    private void changeColor(){
        state = states[lightCount];
        if (lightCount < states.Count - 1){
            lightCount++;
        }
    }
}
