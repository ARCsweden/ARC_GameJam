using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlapInput : MonoBehaviour
{
    public float finPos;
    float getInputFinDown;
    float getInputFinUp;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        finPos = getInputFinUp - getInputFinDown;
        //Debug.Log("FinPos: " + finPos);
    }

    private void OnFinUp(InputValue input)
    {

        getInputFinUp = input.Get<float>();
        //Debug.Log("FinUp: " + getInputFinUp);

    }

    private void OnFinDown(InputValue input)
    {

        getInputFinDown = input.Get<float>();
        

    }
}
