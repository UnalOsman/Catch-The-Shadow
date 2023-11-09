using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    public float HareketAraligi = 2.0f;
    float yMin = -3.6f;
    float yMax = 5.64f;

    float tolerans = 0.5f;

    private float targetY;


    public Transform ball;
    public GameObject DeathPnl;
    public UI ui;

    private void Start()
    {
        ui=FindObjectOfType<UI>();
        HedefBelirle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float yukseklikFarki = Mathf.Abs(ball.transform.position.y - transform.position.y);

            Debug.Log("Yükseklik Farký: " + yukseklikFarki);
            Debug.Log("Ball Yükseklik: " + ball.transform.position.y);
            Debug.Log("Shadow Yükseklik: " + transform.position.y);

            if (yukseklikFarki <= tolerans)
            {
                Debug.Log("Catch the Shadow");
                CatchTheShadow();
            }
            else
            {
                Time.timeScale = 0.0f;
                DeathPnl.SetActive(true);
            }
        }

    }


    public void CatchTheShadow()
    {
        
            HedefBelirle();
            transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }

    public void HedefBelirle()
    {
        targetY = Random.Range(yMin, yMax);
    }
}
