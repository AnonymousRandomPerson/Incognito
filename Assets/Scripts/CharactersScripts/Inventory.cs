using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Keeps track of the items the player has stolen.
/// </summary>
public class Inventory : MonoBehaviour {
    bool gotenough;
    bool gotall;
    /// <summary> The items that the player has stolen. </summary>
    private List<Loot> inventory;

    /// <summary> Whether the player has collected enough loot to finish the level. </summary>
    public bool hasEnoughLoot {
        get { return inventory.Count >= LootManager.instance.numNeededLoot; }
    }

    public bool hasAllLoot{
        get { return inventory.Count == LootManager.instance.getLoot(); }
    }

    /// <summary> The audio source on the player. </summary>
    private AudioSource audioSource;

    public promptManager pM;
    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        inventory = new List<Loot>();
        audioSource = GetComponent<AudioSource>();
        gotenough = false;
        gotall = false;
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
            if (!gotenough && hasEnoughLoot)
            {
                pM.showPartialLootMessage();
                gotenough = true;
            }
            if (!gotall && hasAllLoot)
            {
                pM.showCompleteLootMessage();
                gotall = true;
            }
        }
    }
}