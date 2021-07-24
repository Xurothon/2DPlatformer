using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;
    private LevelManager theLevelManager;

	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	void Update () {
	
	}

    public void Restart() {
        PlayerPrefs.SetInt("CoinCout", 0);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect() {
        PlayerPrefs.SetInt("CoinCout", 0);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu() {
        SceneManager.LoadScene(mainMenu);
    }

}
