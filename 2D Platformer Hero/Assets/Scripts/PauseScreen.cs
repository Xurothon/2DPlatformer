using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;
    public GameObject thePauseScreen;
    private PlayerController _player;
    private LevelManager _levelManager;

    public void PauseGame()
    {
        Time.timeScale = 0;
        thePauseScreen.SetActive(true);
        _player.canMove = false;
    }

    public void ResumeGame()
    {
        thePauseScreen.SetActive(false);
        Time.timeScale = 1;
        _player.canMove = true;
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerLives", _levelManager.currentLives);
        PlayerPrefs.SetInt("CoinCount", _levelManager.coinCount);
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSelect);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        _player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}
