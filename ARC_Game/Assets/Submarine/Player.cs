using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    // Rigidbody references:
    public Rigidbody MainSubRigidbody;
    public Rigidbody LeftThrusterRigidbody;
    public Rigidbody RightThrusterRigidbody;

    // Particle system references:
    public ParticleSystem LeftThrusterParticleSystem;
    public ParticleSystem RightThrusterParticleSystem;

    // Public variables:
    public float ThrustPower = 1000;
    public float ParticlePower;
    public int ParticleEmissionRateOverTime = 20;

    // Internal variables:
    Vector3 SteerInputRightThrust;
    Vector3 SteerInputLeftThrust;

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
        LeftThrusterRigidbody.AddRelativeForce(SteerInputLeftThrust * ThrustPower);
        RightThrusterRigidbody.AddRelativeForce(SteerInputRightThrust * ThrustPower);

        LeftThrusterParticleSystem.startSpeed = ParticlePower * (-SteerInputLeftThrust.y);
        LeftThrusterParticleSystem.emissionRate = ParticleEmissionRateOverTime* Mathf.Abs(SteerInputLeftThrust.y);

        RightThrusterParticleSystem.startSpeed = ParticlePower * (-SteerInputRightThrust.y);
        RightThrusterParticleSystem.emissionRate = ParticleEmissionRateOverTime * Mathf.Abs(SteerInputRightThrust.y);
    }

    private void OnRightThruster(InputValue Input)
    {
        Vector2 getInputRightThrust = Input.Get<Vector2>();
        Debug.Log("Right Stick - X: " + getInputRightThrust.x + "     Y: " + getInputRightThrust.y);

        SteerInputRightThrust = new Vector3(0, -getInputRightThrust.y, 0);
    }

    private void OnLeftThruster(InputValue Input)
    {
        Vector2 getInputLeftThrust = Input.Get<Vector2>();
        Debug.Log("Left Stick - X: " + getInputLeftThrust.x + "     Y: " + getInputLeftThrust.y);

        SteerInputLeftThrust = new Vector3(0, -getInputLeftThrust.y, 0);
    }
}
