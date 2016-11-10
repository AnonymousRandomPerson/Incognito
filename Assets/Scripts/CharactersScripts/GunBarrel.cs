using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class GunBarrel : MonoBehaviour {
    public ParticleSystem barrelParticles;
    public AudioSource barrelSoundSource;
    public AudioClip gunshot;

    private AudioSource aud;

    public void Fire()
    {
        barrelParticles.Play();
        barrelSoundSource.clip = gunshot;
        barrelSoundSource.Play(); 
    }
}
