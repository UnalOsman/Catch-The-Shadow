using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    private RectTransform rectTransform;

    public float SlowDownAmount = 2.0f;
    public float ActiveDuration = 4.0f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        RandomPosition();
    }

   
    void Update()
    {
        if(isActive)
        {
            activeTimer += Time.deltaTime;

            if(activeTimer >= ActiveDuration)
            {
                setInActive();
            }

        }
    }

    public void OnSuccessfulCatch()
    {
        slowDownBall();
    }

    private void slowDownBall()
    {
        FindObjectOfType<BallMovement>().Speed -= SlowDownAmount;

        if(isActive)
        {
            setInActive();
        }

        setActive();
    }


    private void setActive()
    {
        isActive = true;
        activeTimer = 0f;
        RandomPosition();
        gameObject.SetActive(true);
    }

    private void setInActive()
    {
        isActive = false;
        gameObject.SetActive(false);
    }




    void RandomPosition()
    {
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        float randomX = Random.Range(0.1f, 0.45f); // Uygun bir x aralýðý seç
        float randomY = Random.Range(-0.4f, 0.45f); // Uygun bir y aralýðý seç

        rectTransform.anchoredPosition = new Vector2(randomX * Screen.width, randomY * Screen.height);
    }


    private bool isActive=false;
    private float activeTimer = 0f;
}
