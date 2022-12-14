using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitGame()
    {
        QuitGame();
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
