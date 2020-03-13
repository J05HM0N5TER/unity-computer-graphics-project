using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public Button runToggle = null;
	public Animator charmeleon = null;
	private bool isRunning = false;

	// Start is called before the first frame update
	void Start()
	{
		if (!runToggle)
		{
			Debug.LogError(nameof(runToggle) + " is not set");
		}
		else
		{
			// Set runToggleOnClick to run when button is pressed
			runToggle.onClick.AddListener(runToggleOnClick);
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	/// <summary>
	/// Runs when runToggle button is clicked
	/// </summary>
	void runToggleOnClick()
	{
		if (isRunning)
		{
			charmeleon.SetTrigger("idleTransition");
		}
		else
		{
			charmeleon.SetTrigger("runTransition");
		}
		isRunning = !isRunning;
	}
}
