using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliffmover : MonoBehaviour
{
    public float velocity = 1;
    private float xPos;
    // Start is called before the first frame update
    void Start()
    {
        xPos = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, velocity, 0);
        if (gameObject.transform.position.y > 100)
        {
            gameObject.transform.position = new Vector3(xPos, -50, 10.1f);
        }
    }
}
