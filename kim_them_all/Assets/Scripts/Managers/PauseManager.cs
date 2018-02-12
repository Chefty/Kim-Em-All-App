using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	
	public GameObject pauseCanvas;
    private bool pause = false;

	void Start()
	{

	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            Pause();
		}
	}
	
	public void Pause()
	{
        pause = !pause;
        pauseCanvas.SetActive(pause);
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;    
        AudioListener.pause = pause;
        Cursor.visible = pause;
    }
}
