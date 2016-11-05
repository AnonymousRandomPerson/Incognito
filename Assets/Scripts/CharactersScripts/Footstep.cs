using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]
public class Footstep : MonoBehaviour {

    private AudioSource aud;
    private ParticleSystem ps;

    void Awake()
    {
        aud = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
    }

    public void Step(AudioClip sound, Color color, float volume)
    {

        if (sound != null && !aud.isPlaying)
        {
            aud.clip = sound;
            aud.volume = volume;
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
        }



            ps.startColor = color;
            //if (ps.isPlaying)
            //{
            //    ps.Stop();
            //}
            ps.Play();
    }
}
