using UnityEngine;
using System.Collections;

public class SoundControl : MonoBehaviour {
	private AudioSource[] audioSources;
	private int audioNum;
	// Use this for initialization
	void Start () {
		audioSources = GetComponents<AudioSource> ();
		audioNum = audioSources.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Plays a sound if an audio source is available, otherwise returns false
	public bool PlayAudio(AudioClip clip){
		bool played = false;

		// Iterates through all audio sources until a free source is found, then plays clip
		for (int i = 0; i < audioNum; i++) {
			if (!audioSources[i].isPlaying)
			{
				audioSources[i].PlayOneShot(clip);
				played = true;
				break;
			}
		}
		return played;
	}
}
