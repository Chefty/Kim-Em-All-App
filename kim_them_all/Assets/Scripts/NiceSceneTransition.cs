using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class NiceSceneTransition : MonoBehaviour {

    public static NiceSceneTransition instance;

    public float transitionTime;

    public bool fadeIn;
    public bool fadeOut;

    public Image fadeImg;

    public AudioClip[] audioClip;

    private AudioSource audioSource;

    // Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            if (fadeIn)
                fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, 1.0f);
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        transitionTime = 1.0f;
    }

    void OnEnable()
    {
        if (fadeIn)
        {
            StartCoroutine(StartScene());
        }
    }

    public void LoadScene(string level)
    {
        StartCoroutine(EndScene(level));
    }

    IEnumerator StartScene()
    {
        float time = 1.0f;
        while (time >= 0.0f)
        {
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, time);
            time -= Time.fixedDeltaTime * (1.0f / transitionTime);
            yield return null;
        }
        fadeImg.gameObject.SetActive(false);
    }

    IEnumerator EndScene(string nextScene)
    {
        fadeImg.gameObject.SetActive(true);
        float time = 0.0f;
        while (time <= 1.0f)
        {
            fadeImg.color = new Color(fadeImg.color.r, fadeImg.color.g, fadeImg.color.b, time);
            time += Time.fixedDeltaTime * (1.0f/transitionTime);
            yield return null;
        }
        yield return new WaitForSeconds(.2f);
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        StartCoroutine(StartScene());
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
            audioSource.clip = audioClip[0];
        if (scene.buildIndex == 1 || scene.buildIndex == 2)
            audioSource.clip = audioClip[1];
        if (scene.buildIndex == 3)
            audioSource.clip = audioClip[2];       
        audioSource.Play();
    }
}
