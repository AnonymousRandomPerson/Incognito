using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays how much loot the player has collected.
/// </summary>
class LootDisplay : MonoBehaviour {

    /// <summary> The prefab for a loot display image. </summary>
    [SerializeField]
    [Tooltip("The prefab for a loot display image.")]
    private LootImage lootImagePrefab;
    /// <summary> The lootImages on display. </summary>
    private LootImage[] lootImages;
    /// <summary> The number of items that have been collected. </summary>
    private int numCollected;

    /// <summary> The singleton instance of the object. </summary>
    public static LootDisplay instance {
        get;
        private set;
    }

    /// <summary>
    /// Initializes the singleton instance of the object.
    /// </summary>
    private void Awake() {
        instance = this;
    }

    /// <summary>
    /// Creates loot images according to the number of items in the level.
    /// </summary>
    public void CreateLootImages(int numLoot) {
        lootImages = new LootImage[numLoot];
        float imageOffset = lootImagePrefab.GetComponent<RectTransform>().rect.width + 10;
        for (int i = 0; i < lootImages.Length; i++) {
            lootImages[i] = GameObject.Instantiate(lootImagePrefab, transform.position, transform.rotation) as LootImage;
            lootImages[i].transform.SetParent(transform);
            lootImages[i].transform.position += Vector3.left * imageOffset * i;
        }

        Text lootText = GetComponentInChildren<Text>();
        lootText.transform.position += Vector3.left * (imageOffset * lootImages.Length + 10);
    }

    /// <summary>
    /// Marks an item as collected on the UI.
    /// </summary>
    public void CollectLoot() {
        lootImages[numCollected++].CollectLoot();
    }
}