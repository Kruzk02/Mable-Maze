using UnityEngine;

public class ScoreManager
{
  private const string BestScoreKey = "BestScore";

  public static int GetBestScore()
  {
    return PlayerPrefs.GetInt(BestScoreKey);
  }

  public static void SetBestScore(int score)
  {
    var bestScore = GetBestScore();
    if (score > bestScore)
    {
      PlayerPrefs.SetInt(BestScoreKey, score);
    }
  }
}