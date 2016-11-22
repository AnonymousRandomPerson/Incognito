using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class promptManager : MonoBehaviour {
    public Animator promptanim;
    public Text promptTextElem;

    private static string interact_message = "Press the Interact button to activate!";
    private static string loot_incomplete_message = "You haven't collected enough loot to escape yet";
    private static string loot_partial_message = "You have enough loot to escape! Or, try to collect them all!";
    private static string loot_complete_message = "You collected all the loot! Try to escape alive!";
    // Use this for initialization
    void Start () {
	}
	

    public void showInteractMessage()
    {
        promptTextElem.text = interact_message;
        promptanim.SetTrigger("prompt");
    }
    public void showPartialLootMessage()
    {
        promptTextElem.text = loot_partial_message;
        promptanim.SetTrigger("prompt");
    }
    public void showCompleteLootMessage()
    {
        promptTextElem.text = loot_complete_message;
        promptanim.SetTrigger("prompt");
    }

    public void showIncompleteLootMessage()
    {
        promptTextElem.text = loot_incomplete_message;
        promptanim.SetTrigger("prompt");
    }

}
