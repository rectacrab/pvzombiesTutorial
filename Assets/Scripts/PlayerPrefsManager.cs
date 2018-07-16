using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MUSIC_VOLUME_KEY = "music_volume";
    const string SFX_VOLUME_KEY = "sfx_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked";

    //initialize the player prefs file
    public static void InitializePlayerPrefs ()
    {
        if (!PlayerPrefs.HasKey(MUSIC_VOLUME_KEY)) { PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, 1f); }

        if (!PlayerPrefs.HasKey(SFX_VOLUME_KEY)) { PlayerPrefs.SetFloat(SFX_VOLUME_KEY, 1f); }
        if (!PlayerPrefs.HasKey(DIFFICULTY_KEY)) { PlayerPrefs.SetInt(DIFFICULTY_KEY, 1); }
        for (int p = 4; p <= SceneManager.sceneCount; p++)
        {
            if (!PlayerPrefs.HasKey(LEVEL_KEY + p.ToString()))
            {
                PlayerPrefs.SetInt(LEVEL_KEY + p.ToString(), 0);
            }
        }
        PlayerPrefs.SetInt(LEVEL_KEY + "3", 1); //level 1 is always unlocked.
    }

    //set MUSIC volume.
    public static void SetMusicVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("music volume is outside of range.");
        }
    }
    //get MUSIC volume.
    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
    }

    //set sfx volume.
    public static void SetSfxVolume(float volume)
    {
        Debug.Log("Setting SFX Volume to: " + volume);
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("SFX volume is outside of range.");
        }
    }
    //get sfx volume.
    public static float GetSfxVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
    }

    //unlock a level for future play.
    public static void UnlockLevel(int levelUnlocked)
    {
        if (levelUnlocked <= SceneManager.sceneCount)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + levelUnlocked.ToString(), 1);
        }
    }

    //check whether a level has been unlocked.
    public static bool GetLevelUnlock(int targetLevel)
    {
        bool isUnlocked = PlayerPrefs.GetInt(LEVEL_KEY + targetLevel.ToString()) == 1;
        if (targetLevel <= SceneManager.sceneCount)
        {
            return isUnlocked;
        }
        else
        {
            Debug.LogError("Trying to check a level that does not exist.");
            return false;
        }
    }

    //set difficutly for the game.
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 0 && difficulty <= 3)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range...");
        }
    }

    //get the difficulty of the game.
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    //reset volume options to defaults.
    public static void SetDefault()
    {
        SetMusicVolume(0.8f);
        SetSfxVolume(0.8f);
    }
}
