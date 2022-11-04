using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public SpawnManager spawnManager;

    public TimerCountdown timerCountdown;
    public GameObject startButton;
    public GameObject resetButton;

    public int score;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public TMP_Text accuracyText;
    public TMP_Text highScoreWall;

    int hasPlayed = 0;

    public bool gameStarted = false;

    private void Awake() {
        MakeSingleton();
    }
    void Start() {
        scoreText.gameObject.SetActive(false);
        accuracyText.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1) {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            PlayerPrefs.SetInt("highscore", 0);
            PlayerPrefs.SetInt("sensitivity", 100);


        }
        highScoreWall.text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();
    }

    // Update is called once per frame
    void Update() {
        if (gameStarted) {
            startGame();
        }
    }

    private void MakeSingleton() {
        if (instance != null) {
            Destroy(gameObject);
        }

        else {
            instance = this;
        
        }
    }

    public void addScore() {
        score++;
    }

    public void startGame() {
        gameStarted = true;
        timerCountdown.gameStarted = gameStarted;

        scoreText.gameObject.SetActive(false);
        accuracyText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);

        resetButton.gameObject.SetActive(true);
    }

    public void endGame() {
        spawnManager.transform.gameObject.SetActive(false);
        spawnManager.DestroyTargets();
        gameStarted = false;
        timerCountdown.gameStarted = gameStarted;
        startButton.SetActive(true);

        if (score > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", score);
            highScoreText.gameObject.SetActive(true);
        }

        scoreText.gameObject.SetActive(true);
        accuracyText.gameObject.SetActive(true);

        scoreText.text = "Score: " + score.ToString();
        accuracyText.text = "Accuracy: " + ((score / spawnManager.totalSpawned) * 100).ToString("F2") + "%";
        highScoreWall.text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();

        resetButton.gameObject.SetActive(false);

        score = 0;
        spawnManager.totalSpawned = 0;
    }

    public void ResetGame() {
        score = 0;
        spawnManager.totalSpawned = 0;

        spawnManager.transform.gameObject.SetActive(false);
        spawnManager.DestroyTargets();
        gameStarted = false;
        timerCountdown.gameStarted = gameStarted;
        startButton.SetActive(true);
        resetButton.gameObject.SetActive(false);
        timerCountdown.secondsLeft = 60;
        timerCountdown.textDisplay.text = "1:00";
    }

}
