using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public GameObject carro;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.name == "Purple_Car" )
        {
            carro.GetComponent<Renderer>().material.color=Color.green;
            // poner la velocidad en 0
        }
    }

}
