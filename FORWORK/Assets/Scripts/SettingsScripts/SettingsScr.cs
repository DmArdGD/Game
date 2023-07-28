using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScr : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropDown;
    public Scrollbar mouseSensBar;
    public Text sensBarpos;
    public float sensitivityMouse = 10;
    Resolution[] resolutions;

   
    private void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + "" /*+ resolutions[i].refreshRate /*+ "Hz"*/;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;     
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);

    }
    public void Setfullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
  
    public void ExitSettings()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ChangeSensivity()
    {
        sensitivityMouse = mouseSensBar.value * 100f;
        sensBarpos.text = string.Format("{0}", (int)sensitivityMouse / 10);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropDown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("SensivityPreference", mouseSensBar.value);
    }
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropDown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropDown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullScreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        else Screen.fullScreen = true;

        if (PlayerPrefs.HasKey("SensivityPreference"))        
           mouseSensBar.value = PlayerPrefs.GetFloat("SensivityPreference");
        else
            mouseSensBar.value = 0.71f; 



    }

}
