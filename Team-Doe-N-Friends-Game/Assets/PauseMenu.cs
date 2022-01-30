using System;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] CharacterHolderSO characterHolderSo;
    [SerializeField] WorldSwitcher worldSwitcher;
    public bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    void Awake(){
        characterHolderSo = FindObjectOfType<CharacterHolderSO>();
        worldSwitcher = FindObjectOfType<WorldSwitcher>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        Debug.Log("resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        Debug.Log("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Load Main Menu");
        
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("restart Level");
        characterHolderSo.lifeStateSo.isAlive = characterHolderSo.lifeStateSo.savedIsAliveState;
        characterHolderSo.ResetWorldStateToSavedWorldState();
        worldSwitcher.ChangeWorld();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    } 
}
