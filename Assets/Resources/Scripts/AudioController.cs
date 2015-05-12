using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	/* Create an audio, ambient and music source */
	private AudioSource audioSource;
	private AudioSource ambientSource;
	private AudioSource musicSource;

	/* Create an array with the music */
	public SoundFiles[] audioSource, musicSounds, ambientSounds;

	[System.Serializable]
	public class SoundFiles {
		private AudioClip[] audioSounds;
		private AudioClip[] ambientSounds;
		private AudioClip[] musicSounds;
	}



	private AudioClip result;

	void Start () 
	{
		audioSource = (AudioSource)gameObject.AddComponent <AudioSource>();
		musicSource = (AudioSource)gameObject.AddComponent <AudioSource>();
	}
	
	void Update () {
	
	}

	internal void PlayMusic (string music)
	{
		//SoundFiles musicSounds = new SoundFiles();
		//musicSounds.musicSounds
		float soundVolume = 0;
		
		switch (music) 
		{
		case "menu":
//			result = musicSounds.musicSounds[0];
			soundVolume = 0.2f; 
			break;
		}
//		musicSource.PlayOneShot (result, soundVolume);
	}
	
	internal void StopMusic () 
	{
		musicSource = GameObject.Find ("AudioController(Clone)").GetComponent<AudioSource> ();
		musicSource.Stop ();
	}
}
