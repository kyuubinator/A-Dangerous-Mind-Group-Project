using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    [SerializeField] InputActionProperty _showMenu;
    bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        _isPaused = false;
        Debug.Log("a");
    }

    // Update is called once per frame
    void Update()
    {
        if (_showMenu.action.WasPerformedThisFrame())
        {
            _isPaused = !_isPaused;
        }
        _menu.SetActive(_isPaused);
        OnPauseMenu();
    }

    void OnPauseMenu()
    {
        if (_isPaused)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }
    
    public void ResumeGame()
    {
        _isPaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MiguelTestRoom");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
