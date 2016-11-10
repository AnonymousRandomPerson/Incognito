using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Animates the game over screen fading in.
/// </summary>
public class GameOverScreen : MonoBehaviour {

    /// <summary> The image overlaid over the screen when getting a game over. </summary>
    private Image gameOverImage;
    /// <summary> The text displayed on the screen when getting a game over. </summary>
    private Text gameOverText;
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
    /// Initializes the object.
    /// </summary>
    private void Start() {
        gameOverImage = GetComponent<Image>();
        gameOverText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows the game over screen.
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
        Color newColor = gameOverImage.color;
        newColor.a += alpha;
        gameOverImage.color = newColor;
        newColor = gameOverText.color;
        newColor.a += alpha;
        gameOverText.color = newColor;
    }
}