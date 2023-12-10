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


    private int consecutiveCatches = 0;
    public int requiredConsecutiveCatches = 4;

    public SlowDownController slowDownController;


    private void Start()
    {
        ui=FindObjectOfType<UI>();
        HedefBelirle();

        requiredConsecutiveCatches = Random.Range(3, 6);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float yukseklikFarki = Mathf.Abs(ball.transform.position.y - transform.position.y);


            if (yukseklikFarki <= tolerans)
            {
                CatchTheShadow();
                ui.ScoreFunc();
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

        if(Mathf.Abs(ball.transform.position.y-transform.position.y) <=tolerans)
        {
            consecutiveCatches++;

            if (consecutiveCatches >= requiredConsecutiveCatches)
            {
                if(slowDownController != null)
                {
                    slowDownController.OnSuccessfulCatch();
                }
                consecutiveCatches = 0;
            }
        }
        else
        {
            consecutiveCatches = 0;
        }


            transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
    }

    public void HedefBelirle()
    {
        targetY = Random.Range(yMin, yMax);
    }
}
