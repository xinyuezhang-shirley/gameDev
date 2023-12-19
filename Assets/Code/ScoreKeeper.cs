using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
///
[RequireComponent(typeof(TMP_Text))]
public class ScoreKeeper : MonoBehaviour
{

    /// <summary>
    /// There will only ever be one ScoreKeeper object, so we just store it in
    /// a static field so we don't have to call FindObjectOfType(), which is expensive.
    /// </summary>
    public static ScoreKeeper Singleton;

    /// <summary>
    /// Add points to the score
    /// </summary>
    /// <param name="points">Number of points to add to the score; can be positive or negative</param>
    public static void ScorePoints(int points)
    {
        Singleton.ScorePointsInternal(points);
    }
    public int initial = 0; // Initialize the score

    /// <summary>
    /// Current score
    /// </summary>
    public int Score;

    public int goalScore = 10;

    /// <summary>
    /// Text component for displaying the score
    /// </summary>
    private TMP_Text scoreDisplay;


    /// <summary>
    /// Initialize Singleton and ScoreDisplay.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        Singleton = this;
        scoreDisplay = GetComponent<TMP_Text>();
        // Initialize the display
        ScorePointsInternal(initial);
    }


    /// <summary>
    /// Internal, non-static, version of ScorePoints
    /// </summary>
    /// <param name="delta"></param>
    ///
    private void ScorePointsInternal(int delta)
    {
        Score = Mathf.Max(0, Score + delta);
        scoreDisplay.text = "Collected " + Score.ToString() + "/" + goalScore.ToString();
        if (Score>=10)
        {
            scoreDisplay.color = new Color(63/255f, 120/255f, 87/255f, 255/255f);
        }
    }

    public static bool enoughScore()
    {
        return Singleton.enoughScoreInternal();
    }

    public bool enoughScoreInternal() {
        if (Score>=goalScore)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}