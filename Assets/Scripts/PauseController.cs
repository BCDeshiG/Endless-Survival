using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
	public static bool isPaused = false;
	private Text pauseText;

	// Get pointer to text and hide it
	void Start()
	{
		pauseText = GetComponent<Text>();
		pauseText.enabled = false;
	}

	// Pauses the game
	void Update()
	{
		if(Input.GetButtonDown("Cancel") || Input.GetButtonDown("Submit"))
		{
			if(!isPaused)
			{
				Time.timeScale = 0; // Freeze time
				isPaused = true;
				pauseText.enabled = true;
			}
			else
			{
				Time.timeScale = 1; // Unfreeze time
				isPaused = false;
				pauseText.enabled = false;
			}
		}
	}
}