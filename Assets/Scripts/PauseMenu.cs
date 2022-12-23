using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = true; // Use if you want to be able to close the menu via esc. P.s. I will add it later, maybe.
    // Start is called before the first frame update
	public GameObject pauseMenuUI;
    // Update is called once per frame
    	void Update()
    	{
        	if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause();
		}
    	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}
	
	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}
	public void ExitButton()
	{
		SceneManager.LoadScene(0);
		GameIsPaused = false; 
		Resume(); //if you don't add this, pausemenu will apear if you go from main menu to the scene
	}
}
