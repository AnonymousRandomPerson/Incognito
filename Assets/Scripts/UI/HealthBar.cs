using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
class HealthBar : MonoBehaviour {

    /// <summary> The player's health. </summary>
    private Health health;

    /// <summary> The green part of the health bar. </summary>
    private Image greenBar;

    /// <summary> The relative x position of the health bar's center at full health. </summary>
    private float offsetMinX;
    /// <summary> The width of the health bar at full health. </summary>
    private float sizeDeltaX;

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        greenBar = GetComponent<Image>();
        offsetMinX = greenBar.rectTransform.offsetMin.x;
        sizeDeltaX = greenBar.rectTransform.sizeDelta.x;
        health = FindObjectOfType<Health>();
    }

    /// <summary>
    /// Updates the object.
    /// </summary>
    private void Update() {
        Vector2 offsetMin = greenBar.rectTransform.offsetMin;
        Vector2 sizeDelta = greenBar.rectTransform.sizeDelta;
        sizeDelta.x = sizeDeltaX * health.healthFraction;
        offsetMin.x = offsetMinX;
        greenBar.rectTransform.sizeDelta = sizeDelta;
        greenBar.rectTransform.offsetMin = offsetMin;
    }
}