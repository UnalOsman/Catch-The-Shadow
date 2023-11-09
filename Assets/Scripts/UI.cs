using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject DeathPnl;
    public ShadowBall sb;
    public GameObject Score;
    int score;

    private void Start()
    {
        sb=FindObjectOfType<ShadowBall>();
    }

    public void Restart()
    {
        DeathPnl.SetActive(false);
        Time.timeScale = 1.0f;
        sb.ball.transform.position = Vector3.zero;
        sb.CatchTheShadow();
        score = 0;
    }

    private void Update()
    {
    }


}
