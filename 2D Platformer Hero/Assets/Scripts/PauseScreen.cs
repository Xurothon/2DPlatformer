using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;
    private LevelManager theLevelManager;
    public GameObject thePauseScreen;
    private PlayerController thePlayer;

	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
	}
	
	void Update () {
	    if(Input.GetButtonDown("Pause")){
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
	}

    public void PauseGame() {
        Time.timeScale = 0;
        thePauseScreen.SetActive(true);
        thePlayer.canMove = false;
    }

    public void ResumeGame() {
        thePauseScreen.SetActive(false);
        Time.timeScale = 1;
        thePlayer.canMove = true;
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("CoinCount", theLevelManager.coinCount);
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSelect);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
