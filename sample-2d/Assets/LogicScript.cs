using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int health = 3;


    public Text scoreText;
    public GameObject gameOverScreen;


    void updateText()
    {
        scoreText.text = playerScore.ToString() + " (남은 기회 : " + health + ")";
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
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

        updateText();

        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }

        return isGameOver;
    }
}
