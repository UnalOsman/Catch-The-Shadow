using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float Speed = 1;
    float yMin=-3.6f,yMax=5.64f;


    void Start()
    {
        //transform.position = Vector3.zero;
    }

    void Update()
    {

        if (transform.position.y <yMax)
        {
            Debug.Log("þuan yukarý gitmesi lazým");
            upMovement();
        }
        else if (transform.position.y >yMin)
        {
            Debug.Log("þuan aþaðý gitmesi lazým");
            transform.position = new Vector3(0, yMax, 0);
            downMovement();
        }
    }


    void upMovement()
    {
        
       transform.position = new Vector3(transform.position.x, transform.position.y + Speed * Time.deltaTime, transform.position.z);
       transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, yMin, yMax),transform.position.z);


        
    }

    void downMovement()
    {
        
        transform.position = new Vector3(transform.position.x, -transform.position.y + Speed * Time.deltaTime, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, yMin, yMax), transform.position.z);

        
    }
}
