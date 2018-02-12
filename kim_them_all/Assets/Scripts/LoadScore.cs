using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int score = PlayerPrefs.GetInt("HighScore");
        gameObject.GetComponent<Text>().text += score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
