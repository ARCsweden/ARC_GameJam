using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoMotion : MonoBehaviour
{
    private Rigidbody torp;
    public float torpThrust = 1;

    // Start is called before the first frame update
    void Start()
    {
        torp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0.0f, torpThrust, 0.0f);

        torp.AddRelativeForce(movement);
    }
}
