using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_color : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Get the Renderer component from the new cube
       var playerRenderer = gameObject.GetComponent<Renderer>();

       //Call SetColor using the shader property name "_Color" and setting the color to red
       playerRenderer.material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
