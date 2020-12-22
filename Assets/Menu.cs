using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
	public AudioMixer audioMixer;
	Resolution[] Resolutions;
	public Dropdown resDropDown;
	int currentResolution = 0;
	List<string> options = new List<string>();

	public void Start()
	{
		Resolutions = Screen.resolutions;
		resDropDown.ClearOptions();
		//resDropDown.ClearOptions();



		for (int i = 0; i < Resolutions.Length; i++)
		{
			string option = Resolutions[i].width + "x" + Resolutions[i].height + " " + Resolutions[i].refreshRate + "Hz";
			options.Add(option);
			if (Resolutions[i].height == Screen.currentResolution.height && Resolutions[i].width == Screen.currentResolution.width)
			{
				currentResolution = i;
			}
		}


		resDropDown.AddOptions(options);
		resDropDown.value = currentResolution;
		resDropDown.RefreshShownValue();

	}

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = Resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public void menu(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
