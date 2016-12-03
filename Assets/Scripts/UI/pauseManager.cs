using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pauseManager : MonoBehaviour {
    public Canvas pauseCanvas;
    bool paused;

    public Canvas helpCanvas;
    public RawImage pc, controller;
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
            if (helpCanvas.enabled)
            {
                helpCanvas.enabled = false;
                helpCanvas.GetComponent<CanvasGroup>().interactable = false;
                pauseCanvas.GetComponent<CanvasGroup>().interactable = true;
                EventSystem.current.SetSelectedGameObject(pauseCanvas.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
            }
            else
            {
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
	}

    public void OnPauseQuitClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menuWithBase");
    }

    public void OnPauseRestartClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnHelpClick()
    {
        Debug.Log("Presed help");
        helpCanvas.enabled = true;
        helpCanvas.GetComponent<CanvasGroup>().interactable = true;
        pauseCanvas.GetComponent<CanvasGroup>().interactable = false;
        EventSystem.current.SetSelectedGameObject(helpCanvas.GetComponentInChildren<UnityEngine.UI.Button>().gameObject);
    }

    public void OnHelpPCClick()
    {
        pc.enabled = true;
        controller.enabled = false;
    }

    public void OnHelpControllerClick()
    {
        pc.enabled = false;
        controller.enabled = true;
    }
}
