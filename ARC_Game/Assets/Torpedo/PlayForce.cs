using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayForce : MonoBehaviour
{
    public int explosionSize = 5;
    public int explosionForce = 5000;

    static List<string> tracked_tags = new List<string> { "Player", "Module", "Torpedo" };

    // Start is called before the first frame update
    void Start()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionSize);
        foreach (var hitCollider in hitColliders)
        {
            if (tracked_tags.Contains(hitCollider.gameObject.tag))
            {
                hitCollider.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce ,transform.position, explosionSize, 0.0f, ForceMode.Impulse);
                //Debug.Log("Player entered explosion");
            }
        }
    }
}
