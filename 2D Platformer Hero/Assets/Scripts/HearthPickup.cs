using UnityEngine;
using System.Collections;

public class HearthPickup : MonoBehaviour {

    public int healthToGive;
    private LevelManager theLevelManager;

	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            theLevelManager.GiveHearth(healthToGive);
            gameObject.SetActive(false);
        }
    }
}
