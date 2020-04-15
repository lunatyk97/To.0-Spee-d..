using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }


    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
