using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlapInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnFinUp(InputValue input)
    {

        float getInputFinUp = input.Get<float>();
        Debug.Log("FinUp: " + getInputFinUp);

    }

    private void OnFinDown(InputValue input)
    {

        float getInputFinDown = input.Get<float>();
        Debug.Log("FinDown: " + getInputFinDown);

    }
}
