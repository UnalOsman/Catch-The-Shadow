using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlowDown : MonoBehaviour , IPointerClickHandler
{
    public RectTransform rectTransform;

    public float SlowDownAmount = 2.0f;
    public float ActiveDuration = 4.0f;

    private bool isActive = false;
    private float activeTimer = 0f;

    private int consecutiveCatches = 0;
    public int requiredConsecutiveCatches = 4;


    void Start()
    {
        //requiredConsecutiveCatches = Random.Range(3, 6);

        //rectTransform = GetComponent<RectTransform>();
    }

   
    void Update()
    {
        /*
       if (!isActive)
        {
            setActive();
        }
       */
    }


    public void OnSuccessfulCatch()
    {

        Debug.Log("onscuccessfulcatch çalýþtý");
        consecutiveCatches++;
        if (consecutiveCatches >= requiredConsecutiveCatches)
        {
            
            RandomPosition();
            Debug.Log("slowDownBall çalýþmalý");
            slowDownBall();
            consecutiveCatches = 0;
        }
    }

    private void slowDownBall()
    {

        Debug.Log("slowdownball çalýþtý");
        
            if (isActive)
            {
                FindObjectOfType<BallMovement>().Speed -= SlowDownAmount;

                setInActive();
            }
       
    }


    public void setActive()
    {

        Debug.Log("setactive çalýþtý");
        isActive = true;
        activeTimer = 0f;
        RandomPosition();
        gameObject.SetActive(true);
    }

    private void setInActive()
    {
        Debug.Log("insetactive çalýþtý");
        isActive = false;
        gameObject.SetActive(false);
    }




    void RandomPosition()
    {
        Debug.Log("random posizyon ayarlandý");
        
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);

            float randomX = Random.Range(0.1f, 0.45f); // Uygun bir x aralýðý seç
            float randomY = Random.Range(-0.4f, 0.45f); // Uygun bir y aralýðý seç

            rectTransform.anchoredPosition = new Vector2(randomX * Screen.width, randomY * Screen.height);
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            slowDownBall();
        }
    }
}
