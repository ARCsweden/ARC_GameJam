using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_color : MonoBehaviour
{
    // List of available colors shared by each player instance
    static List<UnityEngine.Color> availableColors = new List<UnityEngine.Color> { Color.black, Color.blue, Color.cyan, Color.green, Color.grey, Color.magenta, Color.red, Color.white, Color.yellow };

    // Start is called before the first frame update
    void Start()
    {
        //Get the Renderer component from the new player
        var playerRenderer = gameObject.GetComponent<Renderer>();

        // If no colors are available, use green
        int count = availableColors.Count;
        if (count < 1)
        {
            //Set the color

            var leftThrusterRenderer = gameObject.transform.Find("Left Thruster").GetComponent<Renderer>();
            leftThrusterRenderer.material.SetColor("_Color", Color.green);

            var rightThrusterRenderer = gameObject.transform.Find("Right Thruster").GetComponent<Renderer>();
            rightThrusterRenderer.material.SetColor("_Color", Color.green);

            var finRenderer = gameObject.transform.Find("Fin").GetComponent<Renderer>();
            finRenderer.material.SetColor("_Color", Color.green);

            playerRenderer.material.SetColor("_Color", Color.green);
        }
        else
        // Use a random color of the available colors and remove that color from the list
        {
            int randomIndex = Random.Range(0, count - 1);
            UnityEngine.Color playerColor = availableColors[randomIndex];
            availableColors.RemoveAt(randomIndex);

            //Set the color

            var leftThrusterRenderer = gameObject.transform.Find("Left Thruster").GetComponent<Renderer>();
            leftThrusterRenderer.material.SetColor("_Color", playerColor);

            var rightThrusterRenderer = gameObject.transform.Find("Right Thruster").GetComponent<Renderer>();
            rightThrusterRenderer.material.SetColor("_Color", playerColor);

            var finRenderer = gameObject.transform.Find("Fin Joint/Fin").GetComponent<Renderer>();
            finRenderer.material.SetColor("_Color", playerColor);

            playerRenderer.material.SetColor("_Color", playerColor);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
