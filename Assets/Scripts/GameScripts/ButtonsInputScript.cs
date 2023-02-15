using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsInputScript : MonoBehaviour
{
    [SerializeField] GameObject[] keys;
    public static char lastInput;

    public static void SetLastInput(string key)
    {
        char[] aux = key.ToUpper().ToCharArray();
        lastInput = aux[0];
    }

    public static char GetLastInput()
    {
        return lastInput;
    }

}
