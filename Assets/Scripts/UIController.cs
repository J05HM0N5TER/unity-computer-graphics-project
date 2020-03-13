using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public ParticleSystem colorChangeParticle = null;
	public Material colourChangeMaterial = null;
	public List<Slider> colourSlidersRGB;
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

		// Check that there is sliders
		if (colourSlidersRGB.Count == 0)
			Debug.LogError(nameof(runToggle) + " is not set");
		else
		{
			foreach(Slider currentColour in colourSlidersRGB)
			{
				// Set up listeners for the slider when they change values
				currentColour.onValueChanged.AddListener(charmeleonSkinColourOnValueChanged);
			}
		}

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

	void charmeleonSkinColourOnValueChanged(float value)
	{
		// The colour that the sliders now represent
		Color newColor = new Color();
		// Calculate new colour off of value in sliders
		for (int i = 0; i < colourSlidersRGB.Count; i++)
		{
			newColor[i] = colourSlidersRGB[i].value;
		}
		newColor.a = 1;

		// Set the cube colour to new colour
		colourChangeMaterial.color = newColor;

		// Change particle start colour to new colour
		ParticleSystem.MainModule particle = colorChangeParticle.main;
		particle.startColor = newColor;
	}
}
