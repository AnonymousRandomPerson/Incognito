using UnityEngine;
using System;

/// <summary>
/// An item for the player to steal.
/// </summary>
class Loot : MonoBehaviour {
    
    /// <summary> The sound played when stealing the item. </summary>
    [SerializeField]
    [Tooltip("The sound played when stealing the item.")]
    private AudioClip stealSound;
    /// <summary> The sound played when stealing the item. </summary>
    public AudioClip StealSound {
        get { return stealSound; }
    }

    /// <summary> The unique index of the loot. </summary>
    public int lootIndex {
        get {
            int startIndex = gameObject.name.IndexOf('(') + 1;
            int numLength = gameObject.name.IndexOf(')') - startIndex;
            return Convert.ToInt32(gameObject.name.Substring(startIndex, numLength));
        }
    }

    /// <summary>
    /// Triggered when the player steals the item.
    /// </summary>
    public void StealItem() {
        gameObject.SetActive(false);
        LootDisplay.instance.CollectLoot();
        Logger.instance.LogLoot(transform.position);
    }
}