using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	// The particle system that is going to change colour
	public ParticleSystem colorChangeParticle = null;
	// The material that is going to change colour
	public Material colourChangeMaterial = null;
	// The array of the colour sliders
	public List<Slider> colourSlidersRGB;
	// The button that toggles the run animation
	public Button runToggle = null;
	// Button to quit application
	public Button quitButton = null;
	// THe animator that is in control of the animations
	public Animator charmeleon = null;
	// Value to keep track of the current state of the animations
	private bool isRunning = false;

	// Start is called before the first frame update
	private void Start()
	{
		// Check that there is a button
		if (!runToggle)
		{
			Debug.LogError(nameof(runToggle) + " is not set");
		}
		else
		{
			// Set runToggleOnClick to run when button is pressed
			runToggle.onClick.AddListener(runToggleOnClick);
		}

		// Check that there is sliders
		if (colourSlidersRGB.Count == 0)
		{
			Debug.LogError(nameof(colourSlidersRGB) + " is not set");
		}
		else
		{
			foreach (Slider currentColour in colourSlidersRGB)
			{
				// Set up listeners for the slider when they change values
				currentColour.onValueChanged.AddListener(charmeleonSkinColourOnValueChanged);
			}
			// Check to make sure that everything has started on the same colour
			charmeleonSkinColourOnValueChanged(0);
		}

		if (!quitButton)
		{
			Debug.LogError(nameof(quitButton) + " is not set");
		}
		else
		{
			quitButton.onClick.AddListener(Application.Quit);
		}

	}

	/// <summary>
	/// Runs when runToggle button is clicked
	/// </summary>
	private void runToggleOnClick()
	{
		// Change the animation to the opposite that it is
		if (isRunning)
		{
			charmeleon.SetTrigger("idleTransition");
		}
		else
		{
			charmeleon.SetTrigger("runTransition");
		}
		// Set current status
		isRunning = !isRunning;
	}

	/// <summary>
	/// Runs when the value of one of the colour sliders change
	/// </summary>
	/// <param name="value">What the value has changed to (not used)</param>
	private void charmeleonSkinColourOnValueChanged(float value)
	{
		// The colour that the sliders now represent
		Color newColor = new Color();
		// Calculate new colour off of value in sliders
		for (int i = 0; i < colourSlidersRGB.Count; i++)
		{
			newColor[i] = colourSlidersRGB[i].value;
		}
		// Set them to be not transparent because for some reason the default is
		newColor.a = 1;

		// Set the cube colour to new colour
		colourChangeMaterial.color = newColor;

		// Change particle start colour to new colour
		ParticleSystem.MainModule particle = colorChangeParticle.main;
		particle.startColor = newColor;
	}
}
