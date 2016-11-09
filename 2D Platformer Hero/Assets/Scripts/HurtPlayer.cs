using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

    private LevelManager theLevelManager;

	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            theLevelManager.Respawn();
        }
    }
}
