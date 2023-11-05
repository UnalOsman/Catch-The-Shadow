using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject DeathPnl;
    

    public void Restart()
    {
        DeathPnl.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
