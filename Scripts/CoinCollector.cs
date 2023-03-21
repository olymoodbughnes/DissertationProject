using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{


    private int totalCoins = 0;
    private int totalScore = 0;
    private int totalLives = 0;
    private int coinCounter = 0;
    private Settings mode;
    private string diff;

    public GameObject Score;
    public GameObject OneUp;
    [SerializeField] private Text coinText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField]
    ScoreKeeper keeper;



    private void Start()
    {
        mode = GameObject.FindGameObjectWithTag("Settings").GetComponent<Settings>();
        
        keeper = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreKeeper>();
        totalLives = gameObject.GetComponent<PlayerDeath>().getLives();
        livesText.text = ": " + totalLives;
    }
    //Collision Detection
    private void OnTriggerEnter2D(Collider2D collision)
    {
        diff = mode.getDifficulty();
        if (collision.gameObject.CompareTag("Coin_Base"))
        {
            Destroy(collision.gameObject);
            ShowScore();
            totalCoins++;
            coinCounter++;
            totalScore += 100;
            scoreText.text = "Score: " + totalScore;
            coinText.text = ": " + totalCoins;           
            keeper.setCoinScore(totalCoins);
        }
        if (diff == "easy")
        {
            if (coinCounter == 5)
            {
                ShowExtraLife();
                GetComponent<PlayerDeath>().addLife();
                livesText.text = ": " + System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt"));

                coinCounter = 0;

            }
        }

        if (diff == "medium")
        {
            if (coinCounter == 10)
            {

                ShowExtraLife();
                GetComponent<PlayerDeath>().addLife();
                livesText.text = ": " + System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt"));

                coinCounter = 0;

            }
        }

        if (diff == "hard")
        {
            if (coinCounter == 15)
            {

                ShowExtraLife();
                GetComponent<PlayerDeath>().addLife();
                livesText.text = ": " + System.Int32.Parse(File.ReadAllText(Application.persistentDataPath + "/Lives.txt"));

                coinCounter = 0;

            }
        }

    }

    private void ShowScore()
    {

        int rand = Random.Range(1, 3);
        int rand2 = 90;
        switch (rand)
        {
            case 1:
                rand2 = Random.Range(0, 90);
                break;

            case 2:
                rand2 = Random.Range(270, 360);
                break;

            case 3:
                rand2 = 0;
                break;
        }


        Instantiate(Score, transform.position + new Vector3(0, 0.2f, 0), Quaternion.Euler(0, 0, rand2));
    }

    private void ShowExtraLife()
    {

        int rand = Random.Range(1, 3);
        int rand2 = 90;
        switch (rand)
        {
            case 1:
                rand2 = Random.Range(0, 90);
                break;

            case 2:
                rand2 = Random.Range(270, 360);
                break;

            case 3:
                rand2 = 0;
                break;
        }


        Instantiate(OneUp, transform.position + new Vector3(0, 0.8f, 0), Quaternion.Euler(0, 0, rand2));
    }

    public void addScore() {
        totalScore += 100;
        scoreText.text = "Score: " + totalScore;
        keeper.setScore(totalScore);

    }   
    public void subScore() {
        totalScore -= 100;
        scoreText.text = "Score: " + totalScore;
        keeper.setScore(totalScore);

    }
}
