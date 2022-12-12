using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{
    public GameObject pauseMenu;
    public Hero hero;
    [SerializeField] KeyCode keyMenuPaused;
    bool isMenuPaused = false;
    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        ActiveMenu();
    }
    void ActiveMenu()
    {
        if (Input.GetKeyDown(keyMenuPaused))
        {
            isMenuPaused = !isMenuPaused;
        }

        if (isMenuPaused)
        {
            pauseMenu.SetActive(true);
            hero.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            hero.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    public void PauseMenuResume()
    {
        isMenuPaused = false;
        Debug.Log("Продолжить");
    }

    public void PauseMenuSettings()
    {
        Debug.Log("Настройки");
    }

    public void PauseMenuMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        Debug.Log("Главное меню");
    }
    public void PauseMenuExit()
    {
        Debug.Log("Пацаны зацените че могу");
        Application.Quit();
    }
}