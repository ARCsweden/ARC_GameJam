using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
