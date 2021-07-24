using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToGive;
    private LevelManager _levelManager;

    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _levelManager.GiveHearth(healthToGive);
            gameObject.SetActive(false);
        }
    }
}
