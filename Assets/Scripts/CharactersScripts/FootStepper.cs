using UnityEngine;
using System.Collections;

/// <summary>
/// Plays footstep sounds when the player is moving.
/// </summary>
public class FootStepper : MonoBehaviour {
    
    /// <summary> The player's controller that keeps track of movement velocity. </summary>
    private UserController controller;

    /// <summary> The default audio clip to play when stepping. </summary>
    [SerializeField]
    [Tooltip("The default audio clip to play when stepping.")]
    private AudioClip defaultClip;
    /// <summary> The default color of footstep particles. </summary>
    [SerializeField]
    [Tooltip("The default color of footstep particles.")]
    private Color defaultColor;
    /// <summary> The source of audio and particles. </summary>
    [SerializeField]
    [Tooltip("The source of audio and particles.")]
    private GameObject emitter;
    /// <summary> Whether to play footstep sounds. </summary>
    [SerializeField]
    [Tooltip("Whether to play footstep sounds.")]
    private bool playSound = true;

    /// <summary>
    /// Finds other needed components on the player.
    /// </summary>
    private void Start() {
        controller = GetComponent<UserController>();
    }

    /// <summary>
    /// Plays a footstep sound and emits footstep particles.
    /// </summary>
    /// <param name="f">The location of the footstep.</param>
    public void PlayStep(Footstep f) {
        Color color = defaultColor;
        AudioClip clip = defaultClip;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, Vector3.down, out hit, 1, 1)) {
            CustomFootstep custom = hit.collider.GetComponent<CustomFootstep>();
            if (custom != null) {
                color = custom.color;
                clip = custom.clip;
            }
        }
        if (!playSound) {
            clip = null;
        }
        float volume = 0.5f;
        if (controller != null) {
            volume *= controller.velocity.magnitude;
        }
        f.Step(emitter, clip, color, volume);
    }
}
