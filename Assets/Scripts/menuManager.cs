using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class menuManager : MonoBehaviour {
    public Canvas mainmenu_canvas, credits_canvas;
    public Button[] mainmenu_buttons;
    public Button credits_button;
    int highlighted;
    EventSystem myEventSystem;

    public void OnPlayClick()
    {
        Debug.Log("You have clicked the Play button!");
        SceneManager.LoadScene("AbhishekTest", LoadSceneMode.Single);
    }

    public void OnCreditsClick()
    {
        Debug.Log("You have clicked the Credits button!");
        //mainmenu_canvas.gameObject.SetActive(false);
        //credits_canvas.gameObject.SetActive(true);
        mainmenu_canvas.enabled = false;
        credits_canvas.enabled = true;
        credits_canvas.GetComponentInChildren<Text>()
            .GetComponent<CreditScroller>()
                .enabled = true;
    }

    public void OnQuitClick()
    {
        Debug.Log("You have clicked the Quit button!");
        Application.Quit();
    }

    public void OnCreditsBackClick()
    {
        //mainmenu_canvas.gameObject.SetActive(true);
        //credits_canvas.gameObject.SetActive(false);
        mainmenu_canvas.enabled = true;
        credits_canvas.enabled = false;
        credits_canvas.GetComponentInChildren<Text>()
            .GetComponent<CreditScroller>()
                .enabled = false;
    }

    void Start()
    {
        //mainmenu_canvas.gameObject.SetActive(true);
        //credits_canvas.gameObject.SetActive(false);
        mainmenu_canvas.enabled = true;
        credits_canvas.enabled = false;
        credits_canvas.GetComponentInChildren<Text>()
            .GetComponent<CreditScroller>()
                .enabled = false;
        myEventSystem = EventSystem.current;
        highlighted = 0;
    }


    void Update()
    {
            if (mainmenu_canvas.isActiveAndEnabled)
            {
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
                myEventSystem.SetSelectedGameObject(mainmenu_buttons[highlighted].gameObject);

        }
            else
            {
                highlighted = 0;//highlight the first button in the main menu when gone back
                if (credits_canvas.isActiveAndEnabled)
                     myEventSystem.SetSelectedGameObject(credits_button.gameObject);
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
