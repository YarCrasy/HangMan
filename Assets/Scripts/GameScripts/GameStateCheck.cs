using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateCheck : MonoBehaviour
{
    [SerializeField] GameObject win, lose;
    [SerializeField] GameObject[] dummy;
    [SerializeField] Sprite[] dummyFaces;
    Image dummyFace;

    ParticleSystem.EmissionModule dummySweat;

    

    static int MaxAttemp;
    static int attempts;

    private void Awake()
    {
        MaxAttemp = dummy.Length;
        attempts= 0;
        dummyFace = dummy[0].GetComponent<Image>();
        dummySweat = dummy[0].GetComponent<ParticleSystem>().emission;
    }

    public void CheckState()
    {
        if (!TextDisplayScript.isActualCharacter)
        {
            AddAttempt();
            StartCoroutine(PainFace());
            if (attempts == MaxAttemp - 3)  //pies posando menos estres
            {
                dummySweat.rateOverTime = 1;
            }
            else
            {
                dummySweat.rateOverTime = attempts; //sin pies, colgando; con pies, ultimo intento
            }
            
        }
        TextDisplayScript.isActualCharacter = false;


        if (WordsPool.GetActualWord().ToUpper() == TextDisplayScript.GetDisplayedText().ToUpper())
        {
            WordsPool.AddSuccessed();

            if (PlayerPrefs.GetInt("Record") < WordsPool.GetSuccessedTimes())
            {
                PlayerPrefs.SetInt("Record", WordsPool.GetSuccessedTimes());
            }

            dummySweat.rateOverTime = 0;
            win.SetActive(true);
            StartCoroutine(WaitAndLoadScene(0, "WinScene", false));
        }
        else if (attempts >= MaxAttemp)
        {
            WordsPool.ResetSuccessed();
            dummyFace.sprite = dummyFaces[1];
            StartCoroutine(WaitAndLoadScene(2, "LoseScene", true));
        }
    }

    IEnumerator WaitAndLoadScene(float time, string name, bool lose)
    {
        yield return new WaitForSeconds(time);
        SceneController.AddScene(name);
        if (lose)
        {
            this.lose.SetActive(true);
        }
    }

    IEnumerator PainFace()
    {
        dummyFace.sprite = dummyFaces[2];
        yield return new WaitForSeconds(0.75f);
        if(attempts < MaxAttemp - 1)
        dummyFace.sprite = dummyFaces[0];

    }

    void AddAttempt()
    {
        if (attempts == MaxAttemp - 1)
        {
            dummy[attempts].SetActive(false);
        }
        else if (attempts < MaxAttemp - 1)
        {
            dummy[attempts].SetActive(true);
        }
        
        attempts++;
    }

    public static int GetAttempts()
    {
        return attempts;
    }

}
