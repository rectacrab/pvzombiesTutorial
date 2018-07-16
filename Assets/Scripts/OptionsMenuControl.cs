using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuControl : MonoBehaviour {

    private MusicPlayer musicPlayer;

    [SerializeField]
    private Slider MusicSlider;
    [SerializeField]
    private Slider SfxSlider;
    private LevelControl lvlControl;

	// Use this for initialization
	void Start () {
        musicPlayer = GameObject.FindWithTag("MusicPlayer").GetComponent<MusicPlayer>();
        MusicSlider.value = PlayerPrefsManager.GetMusicVolume();
        SfxSlider.value = PlayerPrefsManager.GetSfxVolume();
        lvlControl = GameObject.FindWithTag("LevelSelector").GetComponent<LevelControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //method to set the music volume for the game.
    public void UpdateMusicVolume()
    {
        float newValue = MusicSlider.value;
        Debug.Log("Updating music value to " + newValue);
        musicPlayer.SetMusicVolume(newValue);
    }

    //method to set the sfx volume for the game.
    public void UpdateSFXVolume ()
    {
        PlayerPrefsManager.SetSfxVolume(SfxSlider.value);
    }

    //return to the main menu.
    public void ReturnToMainMenu ()
    {
        lvlControl.ReturnToMenu();
    }

    //button function to reset all volume properties to default.
    public void ResetToDefault ()
    {
        PlayerPrefsManager.SetDefault();
        SfxSlider.value = PlayerPrefsManager.GetSfxVolume();
        MusicSlider.value = PlayerPrefsManager.GetMusicVolume();
    }
}
