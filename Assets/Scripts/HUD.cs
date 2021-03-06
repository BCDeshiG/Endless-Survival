using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	// Store references to HUD texts
	public Text statusText;
	public GameObject promptObj;
	private Text promptText;
	public GameObject gameOver;
	// Store references to player
	public GameObject player;
	private HealthManager playerHealth;
	// How long prompt text has been displayed
	private float timeGap = 0;
	// How long text should be displayed for
	private float displayLength;
	
	// Start is called before the first frame update
	void Start()
	{
		playerHealth = player.GetComponent<HealthManager>();
		promptText = promptObj.GetComponent<Text>();
		promptObj.SetActive(false);
		gameOver.SetActive(false);
	}

	// Displays prompt for some time
	void Update()
	{
		timeGap += Time.deltaTime;
		// Check if prompt is currently being shown
		if(promptObj.activeInHierarchy)
		{
			// Check if prompt has shown for long enough
			if(timeGap > displayLength)
			{
				promptObj.SetActive(false);
			}
		}
	}

	// Shows the player's health and money
	void FixedUpdate()
	{
		statusText.text = "Health: " + playerHealth.getHealth();
		statusText.text += "  Money: $" + PlayerController.getMoney();
		if(playerHealth.getHealth() <= 0)
		{
			gameOver.SetActive(true);
		}
	}

	// Sets text of prompt for a set time
	public void prompt(string text, float time)
	{
		timeGap = 0;
		displayLength = time;
		promptText.text = text;
		promptObj.SetActive(true);
	}

	// Overload method with default time of 1 second
	public void prompt(string text)
	{
		timeGap = 0;
		displayLength = 1;
		promptText.text = text;
		promptObj.SetActive(true);
	}
}