using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Animates a screen fading in.
/// </summary>
public abstract class FadeInScreen : MonoBehaviour {

    /// <summary> The image overlaid over the screen when displaying the screen. </summary>
    private Image fadeImage;
    /// <summary> The text displayed on the screen when displaying the screen. </summary>
    private Text fadeText;
    /// <summary> The speed that the game over screen fades in at. </summary>
    [SerializeField]
    [Tooltip("The speed that the game over screen fades in at.")]
    private float fadeSpeed;
    /// <summary> The amount of time before resetting the scene. </summary>
    [SerializeField]
    [Tooltip("The amount of time before resetting the scene.")]
    private float startOverTime;
    /// <summary> The time slow multiplier when getting a game over. </summary>
    [SerializeField]
    [Tooltip("The time slow multiplier when getting a game over.")]
    private float timeSlow;

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        fadeImage = GetComponent<Image>();
        fadeText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows the screen.
    /// </summary>
    public void Show() {
        gameObject.SetActive(true);
        Time.timeScale = timeSlow;
        StartCoroutine(StartOver());
    }

    /// <summary>
    /// Restarts the scene after a certain amount of time.
    /// </summary>
    private IEnumerator StartOver() {
        yield return new WaitForSeconds(startOverTime * timeSlow);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Updates the object.
    /// </summary>
    private void Update() {
        float alpha = Time.deltaTime / timeSlow / fadeSpeed;
        Color newColor = fadeImage.color;
        newColor.a += alpha;
        fadeImage.color = newColor;
        newColor = fadeText.color;
        newColor.a += alpha;
        fadeText.color = newColor;
    }
}