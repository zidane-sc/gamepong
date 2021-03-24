using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;
    GameObject mainMenu;
    GameObject howToPlay;

    // Start is called before the first frame update
    void Start()
    {
        howToPlay = GameObject.Find("HowToPlay");
        mainMenu = GameObject.Find("MainMenu");
        howToPlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                BackToMainMenu();
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit()
    {
        howToPlay.SetActive(false);
        mainMenu.SetActive(true);
    }


}
