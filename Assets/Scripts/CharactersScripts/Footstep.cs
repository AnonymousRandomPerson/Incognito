using UnityEngine;
using System.Collections;

public class Footstep : MonoBehaviour {

    /// <summary>
    /// Plays a stepping sound and emits stepping particles.
    /// </summary>
    /// <param name="emitter">The object to emit particles and sound from.</param>
    /// <param name="sound">The sound to play.</param>
    /// <param name="color">The color the particles.</param>
    /// <param name="volume">The volume of the sound.</param>
    public void Step(GameObject emitter, AudioClip sound, Color color, float volume)
    {
        AudioSource aud = emitter.GetComponent<AudioSource>();
        ParticleSystem ps = emitter.GetComponent<ParticleSystem>();
        emitter.transform.position = transform.position;
        if (sound != null && !aud.isPlaying)
        {
            aud.clip = sound;
            aud.volume = volume;
            aud.pitch = Random.Range(0.8f, 1.2f);
            aud.Play();
        }
        ps.startColor = color;
        ps.Emit((int)(20 * volume));
    }
}
