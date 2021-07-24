using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public GameObject deathSplosion;
    public int coinCount;
    public Text coinText;
    public int bonusLifeThreshold;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;
    public int maxHealth;
    public bool invincible;
    public Text livesText;
    public int startingLives;
    public int currentLives;
    public GameObject gameOverScreen;
    private PlayerController _player;
    private ResetOnRespawn[] _objectsToReset;
    private int _health;
    private bool _isRespawn;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _health = maxHealth;
        _objectsToReset = FindObjectsOfType<ResetOnRespawn>();
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        coinText.text = "Coins: " + coinCount;
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else
        {
            currentLives = startingLives;
        }
        livesText.text = "Lives x " + currentLives;
    }

    private void Update()
    {

    }

    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = "Lives x " + currentLives;
        if (currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            _player.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }

    public IEnumerator RespawnCo()
    {
        _player.gameObject.SetActive(false);
        Instantiate(deathSplosion, _player.transform.position, _player.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);
        _health = maxHealth;
        _isRespawn = false;
        UpdateHeartMeter();
        coinCount = 0;
        coinText.text = "Coins: " + coinCount;
        _player.transform.position = _player.respawnPosition;
        _player.gameObject.SetActive(true);
        for (int i = 0; i < _objectsToReset.Length; i++)
        {
            _objectsToReset[i].ResetObject();
            _objectsToReset[i].gameObject.SetActive(true);
        }
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinText.text = "Coins: " + coinCount;
    }

    public void HurtPlayer(int damageToTake)
    {
        if (!invincible)
        {
            _health -= damageToTake;
            UpdateHeartMeter();
            _player.Knockback();
        }
        if (_health <= 0 && !_isRespawn)
        {
            Respawn();
            _isRespawn = true;
        }
    }

    public void GiveHearth(int healthToGive)
    {
        _health += healthToGive;
        if (_health > maxHealth)
        {
            _health = maxHealth;
        }
        UpdateHeartMeter();
    }

    public void UpdateHeartMeter()
    {
        switch (_health)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
        }
    }
}