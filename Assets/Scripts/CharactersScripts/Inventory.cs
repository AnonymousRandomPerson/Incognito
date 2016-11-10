using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Keeps track of the items the player has stolen.
/// </summary>
public class Inventory : MonoBehaviour {

    /// <summary> The items that the player has stolen. </summary>
    private List<Loot> inventory;

    /// <summary> The audio source on the player. </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        inventory = new List<Loot>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Steals an item upon collision.
    /// </summary>
    /// <param name="collider">The collider that was collided with.</param>
    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Loot") {
            Loot loot = collider.GetComponent<Loot>();
            loot.StealItem();
            audioSource.PlayOneShot(loot.StealSound);
            inventory.Add(loot);
        }
    }
}