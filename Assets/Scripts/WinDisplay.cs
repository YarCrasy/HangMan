using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinDisplay : MonoBehaviour
{
    TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();
        txt.text = "Words at once: " + WordsPool.GetSuccessedTimes() + "\n" +
                    "Record: " + PlayerPrefs.GetInt("Record");
    }

}
