using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Canvas controlCanvas;
    public bool wantControlCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (!wantControlCanvas)
            controlCanvas.enabled = false;
    }

    //Scene Management
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
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
