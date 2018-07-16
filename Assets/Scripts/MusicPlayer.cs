using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip[] AudioClips;
    [SerializeField]
    private float MusicFadeSpeed = 0.05f;

	// Use this for initialization
	void Start () {
        audioSource = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
        AudioClips = Resources.LoadAll<AudioClip>("Sounds");
        PlayStartupSound();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //play the startup music.
    public void PlayStartupSound () {
        audioSource.volume = PlayerPrefsManager.GetMusicVolume();
        audioSource.PlayOneShot(AudioClips[0]);
    }

    //set the music volume
    public void SetMusicVolume (float newValue)
    {
        PlayerPrefsManager.SetMusicVolume(newValue);
        audioSource.volume = PlayerPrefsManager.GetMusicVolume();
    }

    //play the music related to a specific level.
    public void PlayMusicForLevel (int levelIndex)
    {
        if (audioSource.clip != AudioClips[levelIndex])
        {
            audioSource.clip = AudioClips[levelIndex];
            audioSource.loop = true;
            audioSource.Play();
            audioSource.volume = 0;
            StartCoroutine(FadeMusic(true));
        }
    }

    //method to fade out some music and replace it with the victory/defeat track.
    public void PlayResultMusic (bool didWin)
    {
        int playindex;
        if (didWin) playindex = 1;
        else playindex = 5;
        StartCoroutine(FadeoutAndPlayResult(playindex));
    }

    //method to fade music in or out.
    IEnumerator FadeMusic (bool turnUp)
    {
        if (turnUp)
        {
            while (audioSource.volume < PlayerPrefsManager.GetMusicVolume())
            {
                audioSource.volume += MusicFadeSpeed;
                yield return null;
            }
        }
        else
        {
            while (audioSource.volume > 0)
            {
                audioSource.volume -= MusicFadeSpeed;
                yield return null;
            }
        }
        
    }

    //fade out and play victory or defeat music.
    IEnumerator FadeoutAndPlayResult (int index)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= MusicFadeSpeed;
            yield return null;
        }
        audioSource.Stop();
        audioSource.clip = AudioClips[index];
        audioSource.loop = false;
        audioSource.volume = PlayerPrefsManager.GetMusicVolume();
        audioSource.Play();
    }
}
