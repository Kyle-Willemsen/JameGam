using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject pauseScreen;
    Animator anim;
    AudioManager audioManager;
    bool paused;
    public bool inGame = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && inGame)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;

            if (paused && Input.GetKeyDown(KeyCode.O))
            {
                pauseScreen.SetActive(false);
                paused = false;
                Time.timeScale = 1;
            }
        }
    }

    public void PlayAnim()
    {
        anim.SetBool("Play", true);
    }

    public void Play()
    {
        //audioManager.Play("UI Play");
        SceneManager.LoadScene(1);
        inGame = true;

    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        paused = false;
    }

    public void ResetGame()
    {
       // LoadSceneAnimation loadSceneAnim = GameObject.Find("Main Camera").GetComponent<LoadSceneAnimation>();
       // loadSceneAnim.Reload();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
