using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	// Load selected level
	public void loadLevel(string level)
	{
		SceneManager.LoadScene(level);
	}

	// Exit Game
	public void exitGame()
	{
		Application.Quit();
	}
}