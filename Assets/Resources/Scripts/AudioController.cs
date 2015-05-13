using UnityEngine;

public class AudioController : MonoBehaviour {

	/* Create an audio, ambient and music source */
	private AudioSource audioSource;
	private AudioSource ambientSource;
	private AudioSource musicSource;
	
	/* Create arrays with the sounds for the sources, serialize it so it is visible in the editor */
	
	[SerializeField] private AudioClip[] audioSounds;
	[SerializeField] private AudioClip[] musicSounds;
	[SerializeField] private AudioClip[] ambientSounds;

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

	internal void PlaySound (string sound)
	{
		/* Declare the AudioClip variable null so it may be used locally(!) */
		AudioSource source = null;
		//float soundVolume = 0;
		
		/* Select the proper audio source and audio clip */
		switch (sound) 
		{
		case "menu":
			//soundVolume = 1.0f; 
			source = musicSource;
			source.clip = musicSounds[0];
			break;
		case "desert":
			//soundVolume = 1.0f; 
			source = ambientSource;
			source.clip = ambientSounds[0];
			break;
		}
		source.Play ();
	}
	
	internal void StopMusic () 
	{
		musicSource = GameObject.Find ("AudioController(Clone)").GetComponent<AudioSource> ();
		musicSource.Stop ();
	}
}
