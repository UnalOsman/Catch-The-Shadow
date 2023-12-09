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

public class HighScoreManager
{
    private GameData gameData;

    public HighScoreManager(GameData gameData)
    {
        this.gameData = gameData;
    }

    public void UpdateHighScore(int currentScore)
    {
        if (currentScore > gameData.HighScore)
        {
            gameData.HighScore = currentScore;
            gameData.SaveHighScore();
        }
    }
}
