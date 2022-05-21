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

    public GameObject prefa;
    public float space = 2;

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
        Debug.Log("Right Stick - X: " + getInputRightThrust.x + "     Y: " + getInputRightThrust.y);

        steerInputRightThrust = new Vector3(0, -getInputRightThrust.y, 0);
    }

    private void OnLeftThruster(InputValue input)
    {
        Vector2 getInputLeftThrust = input.Get<Vector2>();
        Debug.Log("Left Stick - X: " + getInputLeftThrust.x + "     Y: " + getInputLeftThrust.y);

        steerInputLeftThrust = new Vector3(0, -getInputLeftThrust.y, 0);
    }

    private void OnTorpedo()
    {
        //LeftThrusterRigidbody.AddForce(0, 0, 0);
        //RightThrusterRigidbody.AddForce(0, 0, 0);
        /*SteerInputRightThrust = new Vector3(0, 0, 0);
        SteerInputLeftThrust = new Vector3(0, 0, 0);
        gameObject.transform.position = new Vector3(0,0,0);
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        MainSubRigidbody.angularVelocity = Vector3.zero;
        LeftThrusterRigidbody.angularVelocity = Vector3.zero;
        RightThrusterRigidbody.angularVelocity = Vector3.zero;
        MainSubRigidbody.velocity = Vector3.zero;
        LeftThrusterRigidbody.velocity = Vector3.zero;
        RightThrusterRigidbody.velocity = Vector3.zero;
        //SteerInputLeftThrust = new Vector3(0, 10, 0);*/
        Vector3 spawnPoint = gameObject.transform.position + (gameObject.transform.rotation * new Vector3 (0,-space,0));

        GameObject.Instantiate(prefa, spawnPoint, gameObject.transform.rotation);//new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z), gameObject.transform.rotation);
        
    } 

    private void OnReset()
    {
        steerInputRightThrust = new Vector3(0, 0, 0);
        steerInputLeftThrust = new Vector3(0, 0, 0);
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        mainSubRigidbody.angularVelocity = Vector3.zero;
        leftThrusterRigidbody.angularVelocity = Vector3.zero;
        rightThrusterRigidbody.angularVelocity = Vector3.zero;
        mainSubRigidbody.velocity = Vector3.zero;
        leftThrusterRigidbody.velocity = Vector3.zero;
        rightThrusterRigidbody.velocity = Vector3.zero;
    }
}
