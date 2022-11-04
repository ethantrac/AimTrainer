using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public TMP_Text textDisplay;
    public SpawnManager spawnManager;
    public float secondsLeft = 60;
    public bool gameStarted = false;

    public GameManager gameManager;

    void Start() {
        textDisplay.text = "1:00";
    }

    void Update() {
        if(gameStarted && secondsLeft > 0) {
            secondsLeft -= Time.deltaTime;
            if((int)secondsLeft >= 59) {
                textDisplay.text = "1:00";
            }

            else if(secondsLeft < 10) {
                textDisplay.text = "00:0" + Mathf.Round(secondsLeft).ToString();
            }

            else {
                textDisplay.text = "00:" + Mathf.Round(secondsLeft).ToString();
            }
            
        }

        if(secondsLeft <= 0) {
            gameManager.endGame();
            secondsLeft = 60;
            textDisplay.text = "1:00";
        }
    }
}
