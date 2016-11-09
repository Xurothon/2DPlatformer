using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;
    public GameObject deathSplosion;
    public int coinCount;
	
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
	
	}
	
	
	void Update () {
	
	}

    public void Respawn() {
        StartCoroutine("RespawnCo");
    }

    public IEnumerator RespawnCo() {
        thePlayer.gameObject.SetActive(false);
        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd) {
        coinCount += coinsToAdd;
    }
}
