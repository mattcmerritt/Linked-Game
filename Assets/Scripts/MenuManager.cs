using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text PrevScoreText, HighScoreText;

    protected void Start()
    {
        PrevScoreText.text = "Previous Score: " + ScoreManager.GetPrevScore();
        HighScoreText.text = "High Score: " + ScoreManager.GetHighScore();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
