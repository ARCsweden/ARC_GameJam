using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoCollision : MonoBehaviour
{
    public GameObject TorpedoExplosion;
    // Start is called before the first frame update

    void OnCollisionEnter(Collision collision)
    {
        Explode();
    }


    void Explode()
    {
        //Debug.Log("BOOM");
        GameObject Explosion = Instantiate(TorpedoExplosion);
        Explosion.transform.position = transform.position; 
        Destroy(gameObject);
    }
}
