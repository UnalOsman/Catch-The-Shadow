using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowBall : MonoBehaviour
{
    public float Speed = 1f;
    public float HareketAraligi = 2.0f;
    float yMin = -3.6f;
    float yMax = 5.64f;

    float tolerans = 0.5f;

    private float targetY;

    bool yonYukariMi=true;

    Transform ball;


    private void Start()
    {
        ball=GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();

        //HedefBelirle();
    }

    void Update()
    {
        ballMovement();



        if(Input.GetMouseButtonDown(0))
        {
            catchTheShadow();
        }

    }

    void ballMovement()
    {
        float newY = transform.position.y;

        if (yonYukariMi)
        {
            newY += Speed * Time.deltaTime;

            if (newY >= yMax)
            {
                newY = yMax;
                yonYukariMi = false;
            }
        }
        else
        {
            newY -= Speed * Time.deltaTime;

            if (newY <= yMin)
            {
                newY = yMin;
                yonYukariMi = true;
            }
        }

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }


    void catchTheShadow()
    {
        if(ball!=null)
        {
            if(Mathf.Abs(ball.transform.position.y-transform.position.y)<=tolerans)
            {
                HedefBelirle();
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
            }
        }
    }

    public void HedefBelirle()
    {
        targetY = Random.Range(yMin, yMax);
        Invoke("HedefBelirle", HareketAraligi);
    }
}
