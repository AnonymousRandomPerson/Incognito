using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
            if (anyDirectionKey()) toggleSelected();
            updateSelected();
        }
    }

    bool anyDirectionKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)
         || Input.GetKeyDown(KeyCode.LeftArrow) 
         || Input.GetKeyDown(KeyCode.RightArrow)
         || Input.GetKeyDown(KeyCode.DownArrow))
            return true;
        else return false;
    }

    void toggleSelected()
    {
        toggle = !toggle;
    }

    void updateSelected()
    {
        if (toggle) EventSystem.current.SetSelectedGameObject(yes.gameObject);
        else EventSystem.current.SetSelectedGameObject(no.gameObject);
    }
}

