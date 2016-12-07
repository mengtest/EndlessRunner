using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text ScoreText;
    public Text HighScoreText;

    public float ScoreCount;
    public float HighScoreCount;
    public float PointsPerSeconds;

    public bool ScoreIncreasing;

	void Start () {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScoreCount = PlayerPrefs.GetFloat("HighScore");
        }     
    }

    void Update()
    {
        if (ScoreIncreasing)
        {
            ScoreCount += PointsPerSeconds * Time.deltaTime;
        }

        if (ScoreCount > HighScoreCount)
        {
            HighScoreCount = ScoreCount;
            PlayerPrefs.SetFloat("HighScore", HighScoreCount);
        }

        ScoreText.text = "Score: " + Mathf.Round(ScoreCount);
        HighScoreText.text = "High Score: " + Mathf.Round(HighScoreCount);
    }

    public void AddToScore(int sccoreIncrement)
    {
        ScoreCount += sccoreIncrement;
    }
}
