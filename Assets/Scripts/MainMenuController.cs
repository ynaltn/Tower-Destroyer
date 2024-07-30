using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public Button play;
    public Button quit;

    private void Start()
    {
        play.onClick.AddListener(() => StartTheGame());
        quit.onClick.AddListener(() => TurnOffTheGame());
    }

    void TurnOffTheGame()
    {
        Application.Quit();
    }
    void StartTheGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

}
