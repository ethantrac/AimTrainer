using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Text sensText;
    public MouseLook mouseLook;

    public AudioMixer audioMixer;
    public Slider sensSlider;
    public Slider volSlider;

    void Start() {
        sensText.text = "Sensitivity: " + Mathf.Round(mouseLook.mouseSensitivity).ToString();
        sensSlider.value = PlayerPrefs.GetFloat("sensitivity");
        volSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void SetSens(float sens) {

        PlayerPrefs.SetFloat("sensitivity", sens);
        mouseLook.mouseSensitivity = PlayerPrefs.GetFloat("sensitivity");

        sensText.text = "Sensitivity: " + Mathf.Round(mouseLook.mouseSensitivity).ToString();
    }

    public void SetVolume(float volume) {
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        
    }

    public void SetFullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }

    public void resetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }
}
