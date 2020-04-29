using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int difficultyLevel = 1;
    public int MaxDifficultyLevel = 10;
    public int ScoreToNextLevel = 10;
    private float score = 0.0f;
    private bool isDead = false;
    
    public Text scoreText;
    public DeathMenu deathMenu;

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (score >= ScoreToNextLevel)
            LevelUp();

        score += Time.deltaTime * difficultyLevel; 
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficultyLevel == MaxDifficultyLevel)
            return;

        ScoreToNextLevel *= 2;
        //ScoreToNextLevel += 20;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);

        Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        SetScore();
        deathMenu.ToggleEndMenu(score);
    }

    private void SetScore()
    {
        if(PlayerPrefs.GetInt("Highscore") < score)
            PlayerPrefs.SetInt("Highscore", (int)score);
    }
}
