using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class Settings_Menu : MonoBehaviour
{
    Resolution[] resolutions;
    public AudioMixer AudioMixer;
    [SerializeField] private List<string> options;
    [SerializeField] private int i;
    [SerializeField] TextMeshProUGUI Text;
    [SerializeField] string message;
    [SerializeField] int currentResI;
    //[SerializeField] private  res; 

    void Awake()
    {
        SetResolutions();
        i = currentResI;
        ChangeResolution();
        message = resolutions[i].width + " X " + resolutions[i].height;
        
    }


    void Update()
    {
        
    }

    

    public void SetMasterVolume(float volume)
    {
        AudioMixer.SetFloat("Volume", volume);
    } 
    
    public void SetSFXVolume(float volume)
    {
        AudioMixer.SetFloat("SFX", volume);
    } 
    
    public void SetMusicVolume(float volume)
    {
        AudioMixer.SetFloat("Music", volume);
    }

    public void PlayAudio(string name)
    {
        
    }

    public void SetResolutions ()
    {
        
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height + "    " + resolutions[i].refreshRate+"Hz";
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) currentResI = i ;
        }
            
    }

    public void ChangeResolution()
    {
        message = resolutions[i].width + " X " + resolutions[i].height + "    " + resolutions[i].refreshRate + "Hz";
        Text.text = message;
    }


    public void ChangeI(int value)
    {
        i += value;
        if (i > resolutions.Length - 1) i = 0;
        if (i < 0) i = resolutions.Length - 1;
        
    }

    public void SetResolution()
    {
        Resolution resolution = resolutions[i];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
}
