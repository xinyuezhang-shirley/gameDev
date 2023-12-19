using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// Displays the score in whatever text component is store in the same game object as this
/// </summary>
///
[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    float currCountdownValue;

    public int startTime= 60;

    private TMP_Text timeDisplay;

    public static Timer Singleton;

    /// <summary>
    /// Initialize Singleton and ScoreDisplay.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        Singleton = this;
        timeDisplay = GetComponent<TMP_Text>();
        // Initialize the display
        StartCoroutine(StartCountdown());
    }

    public IEnumerator StartCountdown()
    {
        currCountdownValue = startTime;
        while (currCountdownValue > 0)
        {
            timeDisplay.text = "Time Left " + currCountdownValue.ToString() + " secs";
            if (currCountdownValue<=5)
            {
                timeDisplay.color = Color.red;
            }
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if(currCountdownValue <= 0)
        {
            if (ScoreKeeper.enoughScore())
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene("Fail");
            }

        }
    }
}