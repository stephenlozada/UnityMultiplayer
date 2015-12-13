using UnityEngine;
using System.Collections;

public class HelpScreen : MonoBehaviour {

	void OnGUI()
    {
        const int buttonWidth = 150;
        const int buttonHeight = 40;

        Rect buttonRect = new Rect(Screen.width / 9 - (buttonWidth / 2),
            (2 * Screen.height / 2.2f) - (buttonHeight / 2),
            buttonWidth,
            buttonHeight
            );

        if (GUI.Button(buttonRect, "Back"))
        {
            Application.LoadLevel("MenuScreen");
        }
    }
}
