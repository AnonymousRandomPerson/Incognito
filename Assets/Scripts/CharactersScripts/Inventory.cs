using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Keeps track of the items the player has stolen.
/// </summary>
public class Inventory : MonoBehaviour {

    /// <summary> The items that the player has stolen. </summary>
    private List<Loot> inventory;

    /// <summary> The number of items that can be stolen in the level. </summary>
    private int numLoot;

    /// <summary> Whether the player has collected all loot in the scene. </summary>
    public bool hasLoot {
        get { return inventory.Count > 0; }
    }

    /// <summary> The audio source on the player. </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        inventory = new List<Loot>();
        audioSource = GetComponent<AudioSource>();
        Loot[] allLoot = GameObject.FindObjectsOfType<Loot>();
        numLoot = allLoot.Length;
        LootDisplay.instance.CreateLootImages(numLoot);
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