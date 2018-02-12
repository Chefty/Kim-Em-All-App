using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour {

    public Canvas menuQuit;

    public Button start;
    public Button quit;
    public Button mapBtn;

    private string url;

    private void Awake()
    {
        Cursor.visible = true;
    }

    void Start () {
        menuQuit = menuQuit.GetComponent<Canvas>();

        menuQuit.enabled = false;

        start = start.GetComponent<Button>();
        quit = quit.GetComponent<Button> ();
        mapBtn = mapBtn.GetComponent<Button>();

	}

    public void loadFile()
    {
      /*  string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        if (path.Length != 0)
        {
            url = "file:///" + path;
            WWW www = new WWW(url);
            
            imgMap.sprite = Sprite.Create(www.texture, 
                new Rect(0, 0, www.texture.width, www.texture.height), 
                new Vector2(0, 0));
            imgMap.enabled = true;

        }*/
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void onExit()
    {

        menuQuit.enabled = true;
        start.enabled = false;
        quit.enabled = false;
        mapBtn.enabled = false;
    }

    public void onYesExit()
    {
        Application.Quit();
    }

    public void onNo()
    {
        menuQuit.enabled = false;
        start.enabled = true;
        quit.enabled = true;
        mapBtn.enabled = true;
    }

    public void onStart()
    {
        string level = "";
        if (switchLevel.levelMode == true)
            level = "KimThemAll";
        else
            level = "KimThemAllDay";
        if (NiceSceneTransition.instance != null)
        {
            NiceSceneTransition.instance.LoadScene(level);
        }
        else
        {
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }
    }
}
