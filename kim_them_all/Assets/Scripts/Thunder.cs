using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Thunder : MonoBehaviour {

    float nextBlink = 0;
    float activeTime;
    bool isActive;
    Light thunder;
    AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        thunder = GetComponent<Light>();
        thunder.enabled = isActive = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!isActive && Time.time > nextBlink)
        {
            nextBlink = Time.time + Random.Range(8F, 20F); //Randomize next blink
            activeTime = Time.time + Random.Range(0.05F, 0.1F);
            thunder.enabled = isActive = true;
            audio.Play();

        }
        else if(isActive && Time.time > activeTime)
        {
            thunder.enabled = isActive = false;
            
        }
    }
}


/* 
 [RequireComponent(typeof(AudioSource))]
public class ExampleClass : MonoBehaviour {
    void Start() {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        audio.Play(44100);
    }
}
     
     
     
     */
