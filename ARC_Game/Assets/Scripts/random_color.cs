using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_color : MonoBehaviour
{
    // List of available colors shared by each player instance
    public static List<UnityEngine.Color> availableColors = new List<UnityEngine.Color> {new Color(1,0,0,1), new Color(1, 0.2f, 0.5f, 1), Color.grey, Color.magenta, new Color(0.4f, 1f, 0.5f, 1), Color.yellow };

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

            var finRenderer = gameObject.transform.Find("Fin Joint/Fin").GetComponent<Renderer>();
            finRenderer.material.SetColor("_Color", Color.green);

            playerRenderer.material.SetColor("_Color", Color.green);
            Player playerScript = gameObject.GetComponent<Player>();
            playerScript.playerColor = Color.green;
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
            Player playerScript = gameObject.GetComponent<Player>();
            playerScript.playerColor = playerColor;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
