using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class ScriptDeathMenu : MonoBehaviour {

    public Canvas menuQuit;

    public Button start;
    public Button quit;

    private string url;

    private void Awake()
    {
        Cursor.visible = true;
    }

    void Start () {
        start = start.GetComponent<Button>();
        quit = quit.GetComponent<Button> ();
	}

    public void onExit()
    {
        if (NiceSceneTransition.instance != null)
        {
            NiceSceneTransition.instance.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }

    public void onStart()
    {
        string sceneName = PlayerPrefs.GetString("SceneName");
        if (NiceSceneTransition.instance != null)
        {
            NiceSceneTransition.instance.LoadScene(sceneName);
        }
        else
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
