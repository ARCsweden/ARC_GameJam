//Version 1

//TODO Replace FindGameObjectsWithTag

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoHoming : MonoBehaviour
{
    private Rigidbody torp;
    public float torpTorque = 0.01f;
    private GameObject target;
    private Transform targetPos;

    // Start is called before the first frame update
    void Start()
    {
        torp = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FindTarget();

        if(target != null)
        {
            //looks at target and finds how to stear
            targetPos = target.transform;
            Vector3 direction = targetPos.position - torp.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            //applies torpTorque in the direction to hit target
            torp.AddTorque(new Vector3(0.0f, 0.0f, -Mathf.Sign(rotateAmount) * torpTorque));
        }
    }

    private void FindTarget()
    {
        //finds all game object with tag Player
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");

        /*GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        GameObject[] gos = new GameObject[targets.Length + targets.Length];

        targets.CopyTo(gos, 0);
        players.CopyTo(gos, targets.Length);*/

        //finds the Player that is closest in angle to the torpedo and within 45
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = Vector3.Angle(diff, transform.up);
            if (curDistance < distance && curDistance < 45)
            {
                closest = go;
                distance = curDistance;
            }
        }
        target = closest;
    }
}
