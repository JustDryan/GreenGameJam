using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public bool isPauseMenu, hideCursor; //Check if the current controller is being used as a pause menu || Check if you have a game that hides and locks cursor in the game (e.g an FPS)
    bool gamePaused; //Used for Escape button inputs

    public List<GameObject> menuScreens = new List<GameObject>();  //Add any menu GameObject parents to this list - Startup screen should be on 0
    public List<string> scenes = new List<string>(); //Add any scene names to swap to to this list

    void Start()
    {
        Time.timeScale = 1;

        if (!isPauseMenu)
        {
            Cursor.lockState = CursorLockMode.None; //Reveals the cursor
            Cursor.visible = true;

            for (int i = 0; i < menuScreens.Count; i++)
            {
                menuScreens[i].SetActive(false);

                if (i == 0)
                {
                    menuScreens[i].SetActive(true);
                }
            }
        }
        else
        {
            StopActiveScreens();
        }
    }

    void Update()
    {
        if (isPauseMenu)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void SwapActiveScene(int id) //Changes which scene is active from the scenes list
    {
        SceneManager.LoadScene(scenes[id]);
    }

    public void SwapActiveScreen(int id) //Function that swaps between active menu screens from the screen list - e.g options, main menu, etc.
    {
        for (int i = 0; i < menuScreens.Count; i++)
        {
            menuScreens[i].SetActive(false);

            if (i == id)
            {
                menuScreens[i].SetActive(true);
            }
        }
    }

    public void StopActiveScreens()
    {
        for (int i = 0; i < menuScreens.Count; i++)
        {
            menuScreens[i].SetActive(false);
        }
    }

    public void QuitGame() //Function that quits the game
    {
         Application.Quit();
    }

    public void Resume() //Function that resumes the game
    {
        gamePaused = false;
        Time.timeScale = 1;
        StopActiveScreens();
        if (hideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Pause() //Function that pauses the game - If things in your game remain moving once your game is paused you can add your own methods of stopping them here
    {
        Time.timeScale = 0;
        gamePaused = true;
        SwapActiveScreen(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}