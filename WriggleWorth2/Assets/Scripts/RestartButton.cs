using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        MoveCamera.gameover = false;
        Scoring.score = 0;
        Scoring.time = 0;
        Scoring.total = 0;
        MovePlayer.time = Scoring.time;
        CollectibleSetFalse.score = Scoring.score;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
