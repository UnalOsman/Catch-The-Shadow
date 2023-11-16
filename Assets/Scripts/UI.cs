using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject DeathPnl;


    public ShadowBall sb;
    public GameData gameData;
    public BallMovement Bm;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighScore;
    int score=0;
    int bolenScore = 100;

    private void Start()
    {
        sb=FindObjectOfType<ShadowBall>();
        Bm = FindObjectOfType<BallMovement>();
        gameData.LoadHighScore();
        UpdateHighScore();
    }

    public void Restart()
    {
        DeathPnl.SetActive(false);
        Time.timeScale = 1.0f;
        sb.ball.transform.position = Vector3.zero;
        sb.CatchTheShadow();
        score = 0;
        Score.text = score.ToString().PadLeft(5,'0');
        Bm.Speed = 8;
    }

    private void Update()
    {
        updateScore();
        
    }

    public void ScoreFunc()
    {
        score+=10;
        if (score % bolenScore == 0)
        {
            Bm.Speed += 1.5f;
        }
        Score.text=score.ToString().PadLeft(5,'0');

    }

    void updateScore()
    {
        if (score > gameData.HighScore)
        {
            gameData.HighScore = score;
            UpdateHighScore();
            gameData.SaveHighScore();
        }
    }

    public void UpdateHighScore()
    {
        HighScore.text="En yüksek skor "+gameData.HighScore.ToString().PadLeft(5,'0');
    }

}
