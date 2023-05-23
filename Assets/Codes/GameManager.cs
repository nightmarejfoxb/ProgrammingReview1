using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver = false;
    int score = 0;
    public GameObject gameovertext;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI LivesDisplay;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
            score = 0;
            UpdateScore(0);
    }

    public void GameOver()
    {
        gameOver = true;

        //GameObject.Find("spawner").GetComponent<spawner>().StopSpawning();

        gameovertext.SetActive(true);
    }

    public void Incrementscore()
    {
        if (!gameOver)
        {
            score++;
            scoreDisplay.text = score.ToString();

            print(score);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("play sence");
    }

    public void UpdateScore(int scoreToAdd)
    {
        scoreDisplay.text = "score =" + score;
        score += scoreToAdd;
    }
}
