using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;
	
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
        yield return new WaitForSeconds(waitToRespawn);
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }
}
