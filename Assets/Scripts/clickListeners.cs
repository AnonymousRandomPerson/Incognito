using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clickListeners : MonoBehaviour {

    public void OnPlayClick()
    {
        Debug.Log("You have clicked the Play button!");
    }

    public void OnCreditsClick()
    {
        Debug.Log("You have clicked the Credits button!");
    }

    public void OnQuitClick()
    {
        Debug.Log("You have clicked the Quit button!");
    }
}
