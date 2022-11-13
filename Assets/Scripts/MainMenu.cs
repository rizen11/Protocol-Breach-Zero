using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

	int m_LevelNumber = 4; //Переменна, отвечающая за то, какой уровень загружать.
	public void PlayGame()
	{
	 	SceneManager.LoadScene(LevelNumber); //Загружает сцену один(см. BuildSettings) Решение для загрузики последующих уровней:(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void ExitGame()
	{
		Debug.Log("Пацаны зацените че могу");
		Application.Quit();
	}
	
	//Св-во для изменения переменной, отвечающей за прогрузку уровней
	public int LevelNumber
	{
		get {return m_LevelNumber;}
		set {m_LevelNumber = value;}
	
	}

}
