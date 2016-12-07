using UnityEngine;

/// <summary>
/// Data for producing custom footstep emitters on certain materials.
/// </summary>
public class CustomFootstep : MonoBehaviour {

    /// <summary> The sound to make when stepping on the object. </summary>
    public AudioClip clip;
    /// <summary> The color of particles to emit when stepping on the object. </summary>
    public Color color;
}