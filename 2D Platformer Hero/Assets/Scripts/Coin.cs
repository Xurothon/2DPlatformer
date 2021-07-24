using UnityEngine;

public class Coin : MonoBehaviour
{
    private LevelManager _levelManager;
    public int coinValue;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _levelManager.AddCoins(coinValue);
            gameObject.SetActive(false);
        }
    }
}