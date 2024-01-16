using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int score;
    public int taskScore = 3;

    public void AddScore(int addScore)
    {
        score += addScore;
    }

    public int GetScore()
    {
        return score;
    }
    
    public int GetTaskScore()
    {
        return taskScore;
    }
    
    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void LoadLevelWithScore()
    {
        if (score == taskScore)
        {
            LoadLevel("LevelList");
        }
    }
}
