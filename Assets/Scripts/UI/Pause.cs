using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour {
    public Canvas pauseCanvas;
    bool paused;
	// Use this for initialization
	void Start () {
        paused = false;
        pauseCanvas.enabled = false;
	}
	
	// Update is called once per frame
    void Update () {
        if (paused && Input.GetButtonDown("Fire2")) {
            OnPauseQuitClick();
        }
        if (Input.GetButtonDown("Pause")) {
            if (!paused)
            {
                Time.timeScale = 0;
                pauseCanvas.enabled = true;
                EventSystem.current.SetSelectedGameObject(pauseCanvas.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
            }
            else
            {
                Time.timeScale = 1;
                pauseCanvas.enabled = false;
            }
            paused = !paused;
        }
	}

    public void OnPauseQuitClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menuWithBase");
    }
}
