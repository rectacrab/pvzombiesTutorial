using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashOpen : MonoBehaviour {
    [SerializeField]
    private CanvasGroup splashCanvas;
    [SerializeField]
    private float SceneLoadDelay = 3f;
    [SerializeField]
    private float SplashSpeed = 0.1f;

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.InitializePlayerPrefs();
        StartCoroutine(FadeInSplash());
        Invoke("ChangeScene", SceneLoadDelay);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //commence the changing of scene.
    private void ChangeScene ()
    {
        StartCoroutine("FadeOut");
    }

    //fade out before changing scene.
    IEnumerator FadeOut ()
    {
        while (splashCanvas.alpha > 0)
        {
            splashCanvas.alpha += SplashSpeed * -1;
            yield return null;
        }
        GameObject.FindWithTag("LevelSelector").GetComponent<LevelControl>().ReturnToMenu();
        //SceneManager.LoadScene(1);
    }

    //coroutine to fade in.
    IEnumerator FadeInSplash ()
    {
        while (splashCanvas.alpha < 1)
        {
            splashCanvas.alpha += SplashSpeed;
            yield return null;
        }
    }
}
