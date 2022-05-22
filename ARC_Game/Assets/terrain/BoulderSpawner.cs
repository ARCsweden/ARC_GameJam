using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public GameObject[] Boulders;
    public float boulderDraw = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, boulderDraw) < 1)
        {
            GameObject Boulder =  Instantiate(Boulders[Random.Range(0,Boulders.Length)]);
            if (Random.Range(0,100) <50)
            {
                Boulder.transform.position = new Vector3(-25, -25, 0);
            }
            else
            {
                Boulder.transform.position = new Vector3(25, -25, 0);
            }

            if (Random.Range(0, 100) < 20)
            {
                Boulder.transform.position = new Vector3(Random.Range(-15,15), 40, 0);
                Boulder.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0);
                Destroy(Boulder, 80);
            }
            else
            {
                Boulder.GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 0);
                Destroy(Boulder, 50);
            }

            Boulder.transform.rotation = new Quaternion(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Boulder.transform.localScale = new Vector3(Random.Range(0.8f, 2f), Random.Range(0.8f, 2f), Random.Range(0.8f, 2f));
           
        }
    }
}
