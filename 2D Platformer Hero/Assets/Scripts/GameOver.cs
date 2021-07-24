using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;
    private LevelManager _levelManager;

    public void Restart()
    {
        PlayerPrefs.SetInt("CoinCout", 0);
        PlayerPrefs.SetInt("PlayerLives", _levelManager.startingLives);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("CoinCout", 0);
        PlayerPrefs.SetInt("PlayerLives", _levelManager.startingLives);
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }
}
