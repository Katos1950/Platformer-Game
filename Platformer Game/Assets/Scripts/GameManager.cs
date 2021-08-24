using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas controlCanvas;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas winCanvas;
    [SerializeField] Canvas loseCanvas;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip bgMusic;

    AudioSource audioSource;
    public bool wantControlCanvas;
    LevelCounter levelCounter;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        levelCounter = FindObjectOfType<LevelCounter>();
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
        if (!wantControlCanvas)
        {
            controlCanvas.enabled = false;
            pauseCanvas.enabled = false;
        }
        if(SceneManager.GetActiveScene().name.Contains("Level") && !SceneManager.GetActiveScene().name.Contains("Selector"))//plays only in level 1-11
        {
            audioSource.clip = bgMusic;
            audioSource.Play();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        levelCounter.DetermineMaxLevel(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 0;
        winCanvas.enabled = true;
    }

    public void Death()
    {
        audioSource.clip = deathClip;
        audioSource.Play();
        Time.timeScale = 0;
        loseCanvas.enabled = true;
    }

    public void LoadLevel(GameObject levelName)
    {
        SceneManager.LoadScene(levelName.name);
    }

    //Scene Management
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
