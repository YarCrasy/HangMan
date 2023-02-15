using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplayScript : MonoBehaviour
{
    [SerializeField] GameStateCheck gameStateCheck;
    static TextMeshProUGUI display;
    static char[] charToDisplay;

    public static bool isActualCharacter = false;

    private void Awake()
    {
        display = GetComponent<TextMeshProUGUI>();

        SetDisplay();
    }

    public void UpdateDisplay()
    {
        char[] aux = display.text.ToCharArray();

        for (int i = 0; i < charToDisplay.Length; i++)
        {
            if (ButtonsInputScript.lastInput == charToDisplay[i])
            {
                aux[i] = charToDisplay[i];
                display.text = new string(aux);
                isActualCharacter= true;
            }
        }
    }


    public static void SetDisplay()
    {
        charToDisplay = WordsPool.GetActualCharArray();
        display.text = "";

        for (int i = 0; i < charToDisplay.Length; i++)
        {
            if (charToDisplay[i] == ' ')
            {
                display.text += " ";
            }
            else
            {
                display.text += "_";
            }
            
        }
    }

    public static string GetDisplayedText()
    {
        return display.text;
    }

}
