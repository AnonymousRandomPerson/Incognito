using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A single loot item display on the UI.
/// </summary>
public class LootImage : MonoBehaviour {

    /// <summary> Whether the loot has been collected. </summary>
    private bool collected;

    /// <summary> The color to change to when the loot is collected. </summary>
    [SerializeField]
    [Tooltip("The color to change to when the loot is collected.")]
    private Color collectColor;
    private Color initColor;

    /// <summary> The amount of seconds taken for the image to change color. </summary>
    [SerializeField]
    [Tooltip("The amount of seconds taken for the image to change color.")]
    private float appearTime;
    /// <summary> The time that the loot was collected at. </summary>
    private float startTime;

    /// <summary> The image to display on the screen. </summary>
    private Image image;

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        image = GetComponent<Image>();
        initColor = image.color;
    }

    public void CollectLoot() {
        collected = true;
        startTime = Time.time;
    }

    /// <summary>
    /// Updates the object.
    /// </summary>
    private void Update() {
        if (collected) {
            image.color = Color.Lerp(initColor, collectColor, (Time.time - startTime) / appearTime);
        }
    }
}