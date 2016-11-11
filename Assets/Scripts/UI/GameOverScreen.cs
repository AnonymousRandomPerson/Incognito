using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Animates the game over screen fading in.
/// </summary>
public class GameOverScreen : FadeInScreen {

    /// <summary> The singleton instance of the object. </summary>
    public static GameOverScreen instance {
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
    /// Gets the scene to load after the screen has been shown for a while.
    /// </summary>
    /// <returns>The scene to load after the screen has been shown for a while.</returns>
    protected override string GetTransitionScene() {
        return SceneManager.GetActiveScene().name;
    }
}