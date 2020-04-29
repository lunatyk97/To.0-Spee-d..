using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{
    public GameObject PauseMenu;

    private bool paused = false;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    private void Pause()
    {
        paused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    private void UnPause()
    {
        //if (isDead)
        //    return;
       
        Time.timeScale = 1f;
        paused = false;
        PauseMenu.SetActive(false);
        Cursor.visible = false;
    }

    public void setDeath()
    {
        isDead = true;
        Debug.Log("Dead Unpause");
    }

    public void setUnPause()
    {
        UnPause();
    }
}
