using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerManager playerManager;
    public Color playerColor;
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
    public float health, maxHealth;
    public HealthBar healthBar;

    public GameObject prefa;
    public float space = 2;
    private float thrustRumble = 0.1f;

    public int playerIndex;

    // Internal variables:
    Vector3 steerInputRightThrust;
    Vector3 steerInputLeftThrust;

    private bool cooldown = false;
    private Gamepad curr = null;    

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        maxHealth = 100;
        health = maxHealth;
        healthBar.UpdateHealthBar();
        transform.position = new Vector3(Random.Range(-10,10), Random.Range(-10, 10),0);
        curr = Gamepad.current;
    }

    private void FixedUpdate()
    {
        leftThrusterRigidbody.AddRelativeForce(steerInputLeftThrust * thrustPower);
        rightThrusterRigidbody.AddRelativeForce(steerInputRightThrust * thrustPower);
    }

    // if damage is taken, calls a function in the healthbar script
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.    
        health -= 10f;
        healthBar.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {

        

        //playerColor = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        leftThrusterParticleSystem.startSpeed = particlePower * (-steerInputLeftThrust.y);
        leftThrusterParticleSystem.emissionRate = particleEmissionRateOverTime* Mathf.Abs(steerInputLeftThrust.y);

        rightThrusterParticleSystem.startSpeed = particlePower * (-steerInputRightThrust.y);
        rightThrusterParticleSystem.emissionRate = particleEmissionRateOverTime * Mathf.Abs(steerInputRightThrust.y);  

        if(health <= 0){
            //random_color.availableColors.Add(playerColor);
            //Destroy(gameObject);
            health = maxHealth;
            resetSub();
            playerManager.removeScore(20, playerIndex);

        }


    }

    private void OnDamage(){
        //Debug.Log("TakeDamage");
        TakeDamage();
    }
    private void OnRightThruster(InputValue input)
    {
        Vector2 getInputRightThrust = input.Get<Vector2>();
        //Debug.Log("Right Stick - X: " + getInputRightThrust.x + "     Y: " + getInputRightThrust.y);

        steerInputRightThrust = new Vector3(0, -getInputRightThrust.y, 0);
        float left = Mathf.Clamp(Mathf.Abs(getInputRightThrust.y), 0, thrustRumble);
        float right = Mathf.Clamp(Mathf.Abs(getInputRightThrust.y), 0, thrustRumble/2);
        if (curr != null)
        {
            curr.SetMotorSpeeds(left,right);
        }
    }

    private void OnLeftThruster(InputValue input)
    {
        Vector2 getInputLeftThrust = input.Get<Vector2>();
        //Debug.Log("Left Stick - X: " + getInputLeftThrust.x + "     Y: " + getInputLeftThrust.y);

        steerInputLeftThrust = new Vector3(0, -getInputLeftThrust.y, 0);
        float left = Mathf.Clamp(Mathf.Abs(getInputLeftThrust.y), 0, thrustRumble);
        float right = Mathf.Clamp(Mathf.Abs(getInputLeftThrust.y), 0, thrustRumble / 2);
        if (curr != null)
        {
            curr.SetMotorSpeeds(left, right);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Torpedo") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Terrain"))
        {
            if(health < 10f && collision.collider.gameObject.CompareTag("Torpedo")){
                GameObject torpedo = collision.gameObject;
                int index = torpedo.GetComponent<TorpedoScript>().owner;
                playerManager.addScore(50, index);
            }
            if(curr != null)
            {
                curr.SetMotorSpeeds(0.75f, 1f);
            }
            
            Invoke("rumbleCooldown",0.2f);
            TakeDamage();
        }
    }

    private void rumbleCooldown()
    {
        if(curr != null)
        {
            curr.SetMotorSpeeds(0f, 0f);
        }
        
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
        if(cooldown == false)
        {
            cooldown = true;
            Vector3 spawnPoint = gameObject.transform.position + (gameObject.transform.rotation * new Vector3 (0,-space,0));
            GameObject torpedo = GameObject.Instantiate(prefa, spawnPoint, transform.rotation);//new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z), gameObject.transform.rotation);
            torpedo.transform.Rotate(Vector3.forward, 180);
            torpedo.GetComponent<Rigidbody>().velocity = mainSubRigidbody.velocity;
            torpedo.GetComponent<Rigidbody>().AddForce(-transform.up * 3000, ForceMode.Impulse);
            torpedo.GetComponent<TorpedoScript>().owner = playerIndex;
            var topedoRenderer = torpedo.GetComponent<Renderer>();
            topedoRenderer.material.SetColor("_Color", playerColor); 
            Invoke("ResetCooldown", 0.7f);
        }
    }
    void ResetCooldown()
    {
        cooldown = false;
    }
    private void OnReset()
    {
        resetSub();
    }

    private void resetSub()
    {
        steerInputRightThrust = new Vector3(0, 0, 0);
        steerInputLeftThrust = new Vector3(0, 0, 0);
        //gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        mainSubRigidbody.angularVelocity = Vector3.zero;
        leftThrusterRigidbody.angularVelocity = Vector3.zero;
        rightThrusterRigidbody.angularVelocity = Vector3.zero;
        mainSubRigidbody.velocity = Vector3.zero;
        leftThrusterRigidbody.velocity = Vector3.zero;
        rightThrusterRigidbody.velocity = Vector3.zero;
        transform.position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }
}
