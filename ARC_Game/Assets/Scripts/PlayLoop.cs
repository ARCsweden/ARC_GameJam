using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLoop : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip[] AudioClips;
    // Start is called before the first frame update
    void Start()
    {
        audiosource.PlayOneShot(AudioClips[Random.Range(0, AudioClips.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(AudioClips[Random.Range(0, AudioClips.Length)]);
        }
    }
}
