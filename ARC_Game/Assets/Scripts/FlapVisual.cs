using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapVisual : MonoBehaviour
{
    public Rigidbody rig;
    public FlapInput flapper;
    float lastAngle = 0;
    float currAngle = 0;
    float flapForce = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Transform flapper.finPos to an angle between -45 and 45, and set the rotation to that
        Quaternion rotation = Quaternion.identity;
        currAngle = Mathf.LerpAngle(-45, 45, (flapper.finPos + 1)/2);
        flapForce = Mathf.Abs((currAngle - lastAngle));
        flapForce = Mathf.Clamp(flapForce, 0, 45) * 500;
        rig.AddForce(-rig.transform.up * flapForce);
        //Debug.Log("flapForce: " + flapForce);
        lastAngle = currAngle;
        rotation.eulerAngles = new Vector3(0 , 0, currAngle);
        gameObject.transform.localRotation = rotation;
    }
}
