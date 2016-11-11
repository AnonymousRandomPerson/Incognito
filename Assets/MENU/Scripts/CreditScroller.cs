using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditScroller : MonoBehaviour {
    public Text creditTextElement;
    float speed;
    bool scrolling;
    

	// Use this for initialization
	void Start () {
        scrolling = false;
        creditTextElement.text = credits;
        speed = 0.0025f * Screen.height;
        float my_y = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (scrolling)
        {
            creditTextElement.rectTransform.Translate(0, speed, 0);
            if (creditTextElement.rectTransform.position.y > (creditTextElement.preferredHeight + Screen.height))
                scrolling = false;
        }
        else OnEnable();
    }
    void OnEnable()
    {
        Debug.Log("Credits is enabled");
        Debug.Log("Screen:" + Screen.height);
        scrolling = true;
        creditTextElement.rectTransform.position = new Vector3(creditTextElement.transform.position.x,
                                                    -0.8f * Screen.height,
                                                    creditTextElement.transform.position.z);
    }

    void OnDisable()
    {
        Debug.Log("Credits was disabled");
        scrolling = false;
    }

    string credits =
        "-INCOGNITO-\n" +
        "\nCredits\n" +
        "TeamMember NameOne\n\n" +
        "TeamMember NameTwo\n\n" +
        "TeamMember NameThree\n\n" +
        "TeamMember NameFour\n\n" +
        "\n" +
        "Resources:\n" +
        "RAIN AI\n" +
        "\n\n\n" +
        "COPYRIGHT: TEAM INCOGNITO\n"+
        "End\n";
}
