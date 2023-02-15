using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject EscAlert;
    static string lastScene, actualScene = "MainMenuScene";


    private void Start()
    {
        ResetPlayerPrefbs();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ActivateEscAlert();
    }

    public void ResetPlayerPrefbs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ActivateEscAlert()
    {
        Time.timeScale = 0;
        EscAlert.SetActive(true);
    }

    public void DeactivateEscAlert()
    {
        Time.timeScale = 1;
        EscAlert.SetActive(false);
    }

    public static void GoToScene(string name)
    {
        lastScene = actualScene;
        actualScene = name;
        SceneManager.LoadScene(name);
    }

    public static void AddScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public static void UnloadScene()
    {

    }

    public static void ExitGame()
    {
        Application.Quit();
    }

}
