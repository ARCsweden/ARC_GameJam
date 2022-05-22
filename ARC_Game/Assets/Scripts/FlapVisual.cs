using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapVisual : MonoBehaviour
{
    public ParticleSystem finParticleSystem;
    public float finEmission = 2;

    public Rigidbody rig;
    public FlapInput flapper;
    float lastAngle = 0;
    float currAngle = 0;
    public float flapForce = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var em = finParticleSystem.emission;

        // Transform flapper.finPos to an angle between -45 and 45, and set the rotation to that
        Quaternion rotation = Quaternion.identity;
        currAngle = Mathf.LerpAngle(-45, 45, (flapper.finPos + 1)/2);

        rotation.eulerAngles = new Vector3(0 , 0, currAngle);
        gameObject.transform.localRotation = rotation;

        // force calc
        flapForce = Mathf.Abs((currAngle - lastAngle) * 1000);
        flapForce = Mathf.Clamp(flapForce, 0, 10000);
        rig.AddForce(-rig.transform.up * flapForce * 0.2f);

        em.rateOverTime = Mathf.Abs((currAngle - lastAngle) * finEmission);

        lastAngle = currAngle;
    }
}
