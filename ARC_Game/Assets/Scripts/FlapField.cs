using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapField : MonoBehaviour
{

    float TBD;
    public FlapVisual flapVisual;
    private HashSet<GameObject> _inrange = new HashSet<GameObject>();

    static List<string> tracked_tags = new List<string> {"Player", "Module", "Torpedo"};

    void OnDisable()
    {
        _inrange.Clear();
    }

    void OnTriggerEnter(Collider c) //change to 2d for 2d
    {
        // Check if object should be affected by flapforce
        if(tracked_tags.Contains(c.gameObject.tag))
        {
            _inrange.Add(c.gameObject);
            //Debug.Log("Player entered my safe space");
        }
        
    }

    void OnTriggerExit(Collider c) //change to 2d for 2d
    {
        _inrange.Remove(c.gameObject);
        //Debug.Log("Player respects my safe space");
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
            if (gB != null)
            {
                Debug.Log(gB.name + ", " + gameObject.name);
                Rigidbody rig = gB.GetComponent<Rigidbody>();
                Vector3 dir = gB.transform.position - gameObject.transform.position;
                rig.AddForce(ff * dir);
            }else
            {
                _inrange.Remove(gB);
                break;
            }

        }
    }
}
