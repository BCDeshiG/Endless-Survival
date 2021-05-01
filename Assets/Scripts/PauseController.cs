using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject pauseText;

	// Get pointer to text and hide it
	void Start()
	{
		pauseText.SetActive(false);
	}

	// Check if pressing pause or dead
	void Update()
	{
		if(Input.GetButtonDown("Cancel"))
		{
			isPaused = !isPaused;
		}
		if(PlayerController.isDead)
		{
			isPaused = true; // 'Pause' game when dead
		}
	}

	void LateUpdate()
	{
		if(isPaused)
		{
			// Show pause text if not dead
			if(!PlayerController.isDead)
			{
				Time.timeScale = 0; // Freeze time
				pauseText.SetActive(true);
			}
		}
		else
		{
			Time.timeScale = 1; // Unfreeze time
			pauseText.SetActive(false);
		}
	}

	// Go back to main menu
	public void mainMenu()
	{
		SceneManager.LoadScene("Main Menu");
	}

	// Exit Game
	public void exitGame()
	{
		Application.Quit();
	}
}