using UnityEngine;

/// <summary>
/// Ends the level if the player interacts with it.
/// </summary>
class Exit : MonoBehaviour, Interactable {

    /// <summary> The sound played when the player wins the level. </summary>
    [SerializeField]
    [Tooltip("The sound played when the player wins the level.")]
    private AudioClip winSound;
    /// <summary> The sound played when the player attempts to exit the level without collecting everything. </summary>
    [SerializeField]
    [Tooltip("The sound played when the player attempts to exit the level without collecting everything.")]
    private AudioClip rejectSound;

    /// <summary>
    /// Causes the player to interact with the object.
    /// </summary>
    /// <param name="player">The player interacting with the object.</param>
    public void Interact(GameObject player) {
        AudioSource audioSource = player.GetComponent<AudioSource>();
        if (player.GetComponent<Inventory>().hasEnoughLoot) {
            audioSource.PlayOneShot(winSound);
            player.GetComponent<Health>().invincible = true;
            LootManager.instance.ResetLoot();
            WinScreen.instance.Show();
        } else {
            audioSource.PlayOneShot(rejectSound);
        }
    }
}