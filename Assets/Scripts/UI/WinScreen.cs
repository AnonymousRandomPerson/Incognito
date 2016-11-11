using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Animates the win screen fading in.
/// </summary>
public class WinScreen : FadeInScreen {

    /// <summary> The singleton instance of the object. </summary>
    public static WinScreen instance {
        get;
        private set;
    }

    /// <summary>
    /// Initializes the singleton instance of the object.
    /// </summary>
    private void Awake() {
        instance = this;
    }
}