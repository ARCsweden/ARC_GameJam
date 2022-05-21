using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapField : MonoBehaviour
{

    float TBD;
    public FlapVisual flapVisual;
    private HashSet<GameObject> _inrange = new HashSet<GameObject>();

    void OnDisable()
    {
        _inrange.Clear();
    }

    void OnTriggerEnter(Collider c) //change to 2d for 2d
    {
        if(c.gameObject.tag == "Player")
        {
            _inrange.Add(c.gameObject);
            Debug.Log("Player entered my safe space");
        }
        
    }

    void OnTriggerExit(Collider c) //change to 2d for 2d
    {
        _inrange.Remove(c.gameObject);
        Debug.Log("Player respects my safe space");
    }


// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ff = flapVisual.flapForce;
        foreach(GameObject gB in _inrange){
            Rigidbody rig = gB.GetComponent<Rigidbody>();
            Vector3 dir = gB.transform.position - gameObject.transform.position;
            Debug.Log("dir: " + dir);
            rig.AddForce(ff * dir);
        }
    }
}
