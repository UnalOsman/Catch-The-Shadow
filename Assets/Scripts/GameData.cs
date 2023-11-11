using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int HighScore=0;

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }

    public void LoadHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            HighScore= PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            HighScore = 0;
        }
    }
}
