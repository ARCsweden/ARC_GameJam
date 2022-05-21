using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    // Rigidbody references:
    public Rigidbody mainSubRigidbody;
    public Rigidbody leftThrusterRigidbody;
    public Rigidbody rightThrusterRigidbody;

    // Particle system references:
    public ParticleSystem leftThrusterParticleSystem;
    public ParticleSystem rightThrusterParticleSystem;

    // Public variables:
    public float thrustPower = 1000;
    public float particlePower;
    public int particleEmissionRateOverTime = 20;

    // Internal variables:
    Vector3 steerInputRightThrust;
    Vector3 steerInputLeftThrust;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftThrusterRigidbody.AddRelativeForce(steerInputLeftThrust * thrustPower);
        rightThrusterRigidbody.AddRelativeForce(steerInputRightThrust * thrustPower);

        leftThrusterParticleSystem.startSpeed = particlePower * (-steerInputLeftThrust.y);
        leftThrusterParticleSystem.emissionRate = particleEmissionRateOverTime* Mathf.Abs(steerInputLeftThrust.y);

        rightThrusterParticleSystem.startSpeed = particlePower * (-steerInputRightThrust.y);
        rightThrusterParticleSystem.emissionRate = particleEmissionRateOverTime * Mathf.Abs(steerInputRightThrust.y);
    }

    private void OnRightThruster(InputValue input)
    {
        Vector2 getInputRightThrust = input.Get<Vector2>();
        //Debug.Log("Right Stick - X: " + getInputRightThrust.x + "     Y: " + getInputRightThrust.y);

        steerInputRightThrust = new Vector3(0, -getInputRightThrust.y, 0);
    }

    private void OnLeftThruster(InputValue input)
    {
        Vector2 getInputLeftThrust = input.Get<Vector2>();
        //Debug.Log("Left Stick - X: " + getInputLeftThrust.x + "     Y: " + getInputLeftThrust.y);

        steerInputLeftThrust = new Vector3(0, -getInputLeftThrust.y, 0);
    }
}
