using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public int health = 3;
    public AudioSource scoreAudioSource;
    public AudioSource collideAudioSource;
    public AudioSource gameOverAudioSource;


    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;


    void updateText()
    {
        scoreText.text = $"Score : {playerScore} (Life: {health})";
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (health == 0)
        {
            return;
        }

        playerScore += scoreToAdd;
        scoreAudioSource.Play();
        updateText();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool collide()
    {
        health = health - 1;
        bool isGameOver = health == 0;
        collideAudioSource.Play();

        updateText();

        if (isGameOver)
        {
            gameOverAudioSource.Play();
            gameOverScreen.SetActive(true);
        }

        return isGameOver;
    }
}
