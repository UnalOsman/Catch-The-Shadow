using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    public float HareketAraligi = 2.0f;
    float yMin = -3.6f;
    float yMax = 5.64f;

    float tolerans = 3f;

    private float targetY;


    Transform ball;


    private void Start()
    {
        ball=GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();

        HedefBelirle();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            float yukseklikFarki = Mathf.Abs(ball.transform.position.y - transform.position.y);

            Debug.Log("Yükseklik Farký: " + yukseklikFarki);
            Debug.Log("Ball Yükseklik: " + ball.transform.position.y);
            Debug.Log("Shadow Yükseklik: " + transform.position.y);

            if (yukseklikFarki<=tolerans && Mathf.Approximately(ball.transform.position.y, transform.position.y))
            {
                Debug.Log("yer deðiþimi");
                StartCoroutine(CatchTheShadowCoroutine());
                
            }
            
        }
    }


    IEnumerator CatchTheShadowCoroutine()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("Coroutine Baþladý");
        HedefBelirle();
        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }

    public void HedefBelirle()
    {
        targetY = Random.Range(yMin, yMax);
    }
}
