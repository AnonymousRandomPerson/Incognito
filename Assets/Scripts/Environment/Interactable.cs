using UnityEngine;

/// <summary>
/// An object that can be interacted with by the player.
/// </summary>
public interface Interactable {

    /// <summary>
    /// Causes the player to interact with the object.
    /// </summary>
    /// <param name="player">The player interacting with the object.</param>
    void Interact(GameObject player);
}