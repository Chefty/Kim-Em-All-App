using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchLevel : MonoBehaviour {
    public static bool levelMode;

    private void Awake()
    {
        levelMode = true;
    }

    public void onStart()
    {
        levelMode = !levelMode;
        if (levelMode)
            gameObject.GetComponentInChildren<Text>().text = "NIGHTMODE";
        else
            gameObject.GetComponentInChildren<Text>().text = "DAYMODE";
    }
}
