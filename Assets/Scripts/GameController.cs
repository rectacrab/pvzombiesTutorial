using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    private int LevelMusicIndex;
    private MusicPlayer musicPlayer;
    [SerializeField]
    private string NextLevelName;
    private string LevelToLoad;
    private LevelControl levelControl;


	// Use this for initialization
	void Start () {
        musicPlayer = GameObject.FindWithTag("MusicPlayer").GetComponent<MusicPlayer>();
        musicPlayer.PlayMusicForLevel(LevelMusicIndex);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //play music, make results.
    public void EndStage (bool hasVictory)
    {
        musicPlayer.PlayResultMusic(hasVictory);
        if (hasVictory)
        {
            LevelToLoad = NextLevelName;
        }
        else
        {
            LevelToLoad = SceneManager.GetActiveScene().name;
        }
    }

    public void ChangeStage ()
    {
        levelControl.StartNamedLevel(LevelToLoad);
    }

}
