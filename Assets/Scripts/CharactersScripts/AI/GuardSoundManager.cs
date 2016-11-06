using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GuardSoundManager : MonoBehaviour {

    public AudioClip callIn;
    public AudioClip persue;

    private AudioSource aud;
	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();
	}
	
	public void playCallin()
    {
        if (!aud.isPlaying)
        {
            aud.clip = callIn;
            aud.Play();
        }
    }

    public void playPersue()
    {
        if (!aud.isPlaying)
        {
            aud.clip = persue;
            aud.Play();
        }
    }
}
