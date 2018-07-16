using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //load next gameplay level.
    public void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //return to main menu
    public void ReturnToMenu ()
    {
        SceneManager.LoadScene(1);
    }

    //quit this piece of shit.
    public void QuitGame ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //load the first level.
    public void StartGame ()
    {
        SceneManager.LoadScene(3);
    }

    //go from a specific point
    public void StartSpecificLevel (int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    //load a level from a string
    public void StartNamedLevel (string levelName)
    {
        Scene targetScene = SceneManager.GetSceneByName(levelName);
        SceneManager.LoadScene(targetScene.buildIndex);
    }
}
