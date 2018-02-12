using UnityEngine;
using System.Collections;

public class randomNoise : MonoBehaviour
{

    public AudioClip[] noise;
    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
            playRandomMusic();
    }

    void playRandomMusic()
    {
        int num = Random.Range(0,10000);
        if (num == 2)
        {
            source.clip = noise[Random.Range(0, noise.Length)];
            source.Play();
        }
    }
}
