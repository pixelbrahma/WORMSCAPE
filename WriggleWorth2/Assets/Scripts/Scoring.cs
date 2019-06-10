using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public static int score = CollectibleSetFalse.score;
    public static float time = MovePlayer.time;
    public static float total = time + score * 5;
    public static float highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    private void Score()
    {
        if (total > highScore)
        {
            highScore = total;
            PlayerPrefs.SetFloat("highScore", highScore);
        }
        if (gameObject.name == "Time")
        {
            GetComponent<TextMeshProUGUI>().text = "TIME : " + time;
        }
        else if(gameObject.name == "Coins")
        {
            GetComponent<TextMeshProUGUI>().text = "COINS : " + score;
        }
        else if(gameObject.name == "Total")
        {
            GetComponent<TextMeshProUGUI>().text = "TOTAL : " + total;
        }
        else if(gameObject.name == "HighScore")
        {
            GetComponent<TextMeshProUGUI>().text = "HIGHSCORE : " + PlayerPrefs.GetFloat("highScore");
        }
    }

    private void Update()
    {
        if(MoveCamera.gameover)
        {
            score = CollectibleSetFalse.score;
            time = MovePlayer.time;
            total = time + score * 5;
            Score();
        }
    }
}
