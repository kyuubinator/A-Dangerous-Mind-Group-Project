using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    [SerializeField] GameObject _settings;
    [SerializeField] InputActionProperty _showMenu;
    bool _isPaused;

    void Start()
    {
        _isPaused = false;
    }

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
        {
            Time.timeScale = 1;
            _menu.SetActive(_settings);
        }
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

    public void SettingsMenu()
    {
        _menu.SetActive(false);
        _settings.SetActive(true);
    }

    public void Pausemenu()
    {
        _menu.SetActive(true);
        _settings.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
