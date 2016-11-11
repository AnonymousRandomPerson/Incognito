using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class menuManager : MonoBehaviour {
    public Canvas mainmenu_canvas, credits_canvas, quit_canvas;
    public Button[] mainmenu_buttons;
    public Button credits_button;
    int highlighted;
    EventSystem myEventSystem;

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Office");
    }

    public void OnCreditsClick()
    {
        Debug.Log(SceneManager.GetSceneByName("Office").buildIndex);
        Debug.Log("You have clicked the Credits button!");
        mainmenu_canvas.enabled = false;
        credits_canvas.enabled = true;
    }

    public void OnQuitClick()
    {
        Debug.Log("You have clicked the Quit button!");
        quit_canvas.enabled = true;
        //Application.Quit();
    }

    public void OnCreditsBackClick()
    {
        mainmenu_canvas.enabled = true;
        credits_canvas.enabled = false;
    }

    public void OnQuitYesPressed()
    {
        Application.Quit();
    }

    public void OnQuitNoPressed()
    {
        quit_canvas.enabled = false;
    }

    void Start()
    {
        mainmenu_canvas.enabled = true;
        credits_canvas.enabled = false;
        quit_canvas.enabled = false;
        myEventSystem = EventSystem.current;
        highlighted = 0;
    }


    void Update()
    {
        if (Input.anyKeyDown) Cursor.visible = false;
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) Cursor.visible = true;
            if (mainmenu_canvas.isActiveAndEnabled)
            {
                if (!quit_canvas.enabled)
                {
                    int oldhighlighted = highlighted;
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                        highlighted--;
                    else if (Input.GetKeyDown(KeyCode.DownArrow))
                        highlighted++;
                    if (highlighted < 0) highlighted = mainmenu_buttons.Length - 1;
                    else highlighted = highlighted % mainmenu_buttons.Length;

                    GameObject gcm = getCurrentMousePointerObject(mainmenu_canvas);
                    if (gcm != null)
                        for (int i = 0; i < mainmenu_buttons.Length; i++)
                            if (mainmenu_buttons[i].gameObject.GetInstanceID() == gcm.GetInstanceID())
                                highlighted = i;
                    mainmenu_buttons[oldhighlighted].GetComponentInChildren<Text>().color = Color.white;
                    mainmenu_buttons[highlighted].GetComponentInChildren<Text>().color = Color.black;
                    myEventSystem.SetSelectedGameObject(mainmenu_buttons[highlighted].gameObject);
                }

        }
            else
            {
                highlighted = 0;//highlight the first button in the main menu when gone back
            if (credits_canvas.isActiveAndEnabled)
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Mouse0))
                    OnCreditsBackClick();
            }
    }

    //Problem in highlighting controls 
    //https://forum.unity3d.com/threads/button-keyboard-and-mouse-highlighting.294147/

    GameObject getCurrentMousePointerObject(Canvas C)
    {
        GraphicRaycaster gr = C.GetComponent<GraphicRaycaster>();
        //Create the PointerEventData with null for the EventSystem
        PointerEventData ped = new PointerEventData(null);
        //Set required parameters, in this case, mouse position
        ped.position = Input.mousePosition;
        //Create list to receive all results
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast it
        gr.Raycast(ped, results);
        if (results.Count >= 2) return results[1].gameObject;
        else return null;
    }
}
