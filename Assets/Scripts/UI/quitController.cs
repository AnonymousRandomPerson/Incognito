using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class quitController : MonoBehaviour
{
    public Button yes, no;
    bool toggle;
    // Use this for initialization
    void Start()
    {
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Canvas>().enabled)
        {
            if (anyDirectionKey()) checkToggle();
            CheckMouseOverQuitButtons();
            updateSelected();
        }
        else toggle = false;  
    }

    bool anyDirectionKey()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Vertical") > 0.5f)
            return true;
        return false;
    }

    void checkToggle()
    {
        toggle = !toggle;
    }

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

    void CheckMouseOverQuitButtons()
    {
        GameObject g = getCurrentMousePointerObject(GetComponent<Canvas>());
        if (g != null)
        {
            //if (g.GetInstanceID() == yes.gameObject.GetInstanceID() || g.GetInstanceID() == no.gameObject.GetInstanceID())
            //    EventSystem.current.SetSelectedGameObject(g);
            if (g.GetInstanceID() == yes.gameObject.GetInstanceID()) toggle = true;
            else if (g.GetInstanceID() == no.gameObject.GetInstanceID()) toggle = false;

        }
    }

    void updateSelected()
    {
        if (toggle)
        {
            yes.GetComponentInChildren<Text>().color = Color.black;
            no.GetComponentInChildren<Text>().color = Color.white;
            EventSystem.current.SetSelectedGameObject(yes.gameObject);
        }
        else
        {
            no.GetComponentInChildren<Text>().color = Color.black;
            yes.GetComponentInChildren<Text>().color = Color.white;
            EventSystem.current.SetSelectedGameObject(no.gameObject);
        }
    }
}

