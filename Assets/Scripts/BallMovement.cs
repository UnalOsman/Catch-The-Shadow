using UnityEngine;

public class BallMovement : MonoBehaviour
{

    
    public float Speed = 1;
    float yMin=-3.6f,yMax=5.64f;

    bool yonYukariMi=true;



    void Update()
    {
        MoveBall();
        
    }

    void MoveBall()
    {
        float newY=transform.position.y;

        if(yonYukariMi)
        {
            newY+=Speed*Time.deltaTime;

            if(newY>=yMax)
            {
                newY=yMax;
                yonYukariMi = false;
            }
        }
        else
        {
            newY-=Speed*Time.deltaTime;

            if (newY<=yMin)
            {
                newY=yMin;
                yonYukariMi = true;
            }
        }

        transform.position = new Vector3(transform.position.x,newY,transform.position.z);
    }
}
