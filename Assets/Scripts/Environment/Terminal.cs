using UnityEngine;

/// <summary>
/// Used to toggle lasers on and off.
/// </summary>
class Terminal : MonoBehaviour, Interactable {

    /// <summary> The laser sensors affected by the terminal. </summary>
    [SerializeField]
    [Tooltip("The laser sensors affected by the terminal.")]
    private LaserSensor[] lasers;

    /// <summary> The audio source on the terminal. </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Causes the player to interact with the object.
    /// </summary>
    /// <param name="player">The player interacting with the object.</param>
    public void Interact(GameObject player) {
        audioSource.Play();
        foreach (LaserSensor laser in lasers) {
            laser.Toggle();
        }
        Logger.instance.LogTerminal(transform.position);
    }
}