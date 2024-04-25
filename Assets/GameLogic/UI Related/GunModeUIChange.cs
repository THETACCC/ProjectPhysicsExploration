using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunModeUIChange : MonoBehaviour
{
    // Reference to the TextMeshPro text component
    public TextMeshProUGUI displayText;

    // Define colors for different modes using hexadecimal values
    private string pullColorHex = "#1EFDFF"; 
    private string dragColorHex = "#E98D08"; 
    private string liftColorHex = "#FF4949"; 
    private string defaultColorHex = "#FFFFFF"; // White

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, set a default text and color when the game starts
        ChangeText("PUSH");
    }

    // Public method to change the display text and color
    public void ChangeText(string mode)
    {
        if (displayText != null)
        {
            displayText.text = mode;
            Color modeColor;
            switch (mode)
            {
                case "PULL":
                    ColorUtility.TryParseHtmlString(pullColorHex, out modeColor); // Convert hex to Color
                    displayText.color = modeColor;
                    break;
                case "PUSH":
                    ColorUtility.TryParseHtmlString(dragColorHex, out modeColor);
                    displayText.color = modeColor;
                    break;
                case "LIFT":
                    ColorUtility.TryParseHtmlString(liftColorHex, out modeColor);
                    displayText.color = modeColor;
                    break;
                default:
                    ColorUtility.TryParseHtmlString(defaultColorHex, out modeColor);
                    displayText.color = modeColor;
                    break;
            }
        }
        else
        {
            Debug.LogError("Display text component not set on " + gameObject.name);
        }
    }
}
