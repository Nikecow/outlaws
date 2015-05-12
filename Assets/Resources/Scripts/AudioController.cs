using UnityEngine;

public class AudioController : MonoBehaviour {

	/* Create an audio, ambient and music source */
	private AudioSource audioSource, ambientSource, musicSource;
	
	/* Create arrays with the sounds for the sources, serialize it so it is visible in the editor */
	[SerializeField]
	private AudioClip[] audioSounds, musicSounds, ambientSounds;

	void Start () 
	{
		CreateSources();
	}
	
	internal void CreateSources()
	{
		audioSource = (AudioSource)gameObject.AddComponent <AudioSource>();
 		musicSource = (AudioSource)gameObject.AddComponent <AudioSource>();
		ambientSource = (AudioSource)gameObject.AddComponent <AudioSource>();
	}
	
	void Update () {
	
	}

	internal void PlayMusic (string music)
	{
		/* Declare the AudioClip variable null so it may be used locally(!) */
		AudioClip result = null;
		float soundVolume = 0;
		
		switch (music) 
		{
		case "menu":
			result = musicSounds[0];
			soundVolume = 1.0f; 
			break;
		}
		musicSource.PlayOneShot (result, soundVolume);
	}
	
	internal void StopMusic () 
	{
		musicSource = GameObject.Find ("AudioController(Clone)").GetComponent<AudioSource> ();
		musicSource.Stop ();
	}
}
