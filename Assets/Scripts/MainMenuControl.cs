using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour {
    [SerializeField]
    private CanvasGroup faderCanvas;
    [SerializeField]
    private float RevealSpeed = 0.05f;
    private LevelControl levelCont;

    // Use this for initialization
    void Start () {
        StartCoroutine("FadeIn");
        GameObject.FindWithTag("MusicPlayer").GetComponent<MusicPlayer>().PlayMusicForLevel(4);
        levelCont = GameObject.FindWithTag("LevelSelector").GetComponent<LevelControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //fade out before changing scene.
    IEnumerator FadeIn()
    {
        while (faderCanvas.alpha > 0)
        {
            faderCanvas.alpha -= RevealSpeed;
            yield return null;
        }
    }

    //method to start the game and change scene.
    public void StartLevel ()
    {
        levelCont.StartGame();
    }

    public void OpenOptions ()
    {
        levelCont.StartSpecificLevel(2);
    }
}
