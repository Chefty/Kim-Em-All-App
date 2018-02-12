using UnityEngine;
using System.Collections;

public class BulletLifeTime : MonoBehaviour {

    // Use this for initialization

    public float lifetime = 2.0f;

    void Awake()
    {
        Destroy(this.gameObject, lifetime);
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
