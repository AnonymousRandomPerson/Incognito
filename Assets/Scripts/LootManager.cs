using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Coordinates the placement of loot in the level.
/// </summary>
public class LootManager : MonoBehaviour {
    
    /// <summary> The number of items that can be stolen in the level. </summary>
    [SerializeField]
    [Tooltip("The number of items that can be stolen in the level.")]
    private int numLoot;

    /// <summary> The number of items that need to be stolen in order to finish the level. </summary>
    [SerializeField]
    [Tooltip("The number of items that need to be stolen in order to finish the level.")]
    public int numNeededLoot;

    /// <summary> The indices of loot objects that were selected to appear in the level. </summary>
    private static HashSet<int> selectedLoot;

    /// <summary> The singleton instance of the object. </summary>
    public static LootManager instance {
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
    /// Selects random loot positions to actually use for the level.
    /// </summary>
    private void Start() {
        Loot[] allLoot = GameObject.FindObjectsOfType<Loot>();
        if (selectedLoot == null) {
            List<Loot> allLootList = new List<Loot>(allLoot.Length);
            foreach (Loot loot in allLoot) {
                allLootList.Add(loot);
                loot.gameObject.SetActive(false);
            }
            selectedLoot = new HashSet<int>();
            for (int i = 0; i < numLoot; i++) {
                int listIndex = Random.Range(0, allLootList.Count);
                Loot loot = allLootList[listIndex];
                selectedLoot.Add(loot.lootIndex);
                loot.gameObject.SetActive(true);
                allLootList.RemoveAt(listIndex);
            }
        } else {
            foreach (Loot loot in allLoot) {
                loot.gameObject.SetActive(selectedLoot.Contains(loot.lootIndex));
            }
        }
        LootDisplay.instance.CreateLootImages(numLoot, numNeededLoot);
    }

    /// <summary>
    /// Resets loot so that it is re-randomized.
    /// </summary>
    public void ResetLoot() {
        selectedLoot = null;
    }
}