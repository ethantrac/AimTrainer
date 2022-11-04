using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSettings : MonoBehaviour {
    public void resetPlayerPrefs() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("sensitivity", 100);
    }

    public void resetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
