using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    private LevelManager theLevelManager;
    public int coinValue;

	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            theLevelManager.AddCoins(coinValue);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}


