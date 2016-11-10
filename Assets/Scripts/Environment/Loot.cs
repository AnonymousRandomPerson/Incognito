using UnityEngine;

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

    /// <summary>
    /// Triggered when the player steals the item.
    /// </summary>
    public void StealItem() {
        gameObject.SetActive(false);
        LootDisplay.instance.CollectLoot();
    }
}