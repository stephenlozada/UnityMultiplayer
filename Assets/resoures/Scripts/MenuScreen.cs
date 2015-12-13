using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour {

	void OnGUI()
    {
        const int buttonWidth = 200;
        const int buttonHeight = 75;

        Rect buttonRect = new Rect(Screen.width / 2 - (buttonWidth / 2),
            (2 * Screen.height / 3.5f) - (buttonHeight / 2),
            buttonWidth,
            buttonHeight
            );
        
        if (GUI.Button(buttonRect, "Play"))
        {
            Application.LoadLevel("Vr");
        }
    }
}
