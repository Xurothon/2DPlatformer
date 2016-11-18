using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;
    private PlayerController thePlayer;
    private CameraController theCamera;
    private LevelManager theLevelManager;
    public float waitToMove;
    public float waitToLoad;
    private bool movePlayer;
    public Sprite flagOpen;
    private SpriteRenderer theSpriteRender;

	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        theLevelManager = FindObjectOfType<LevelManager>();
        theSpriteRender = GetComponent<SpriteRenderer>();
	}
	

	void Update () {
        if (movePlayer) {
            thePlayer.myRigidbody.velocity = new Vector3(thePlayer.moveSpeed,thePlayer.myRigidbody.velocity.y, 0f);
        }
	
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            theSpriteRender.sprite = flagOpen;
            StartCoroutine("LevelEndCo"); 
        }
    }

    public IEnumerator LevelEndCo() {
        thePlayer.canMove = false;
        theCamera.followTarget = false;
        theLevelManager.invincible = true;
        thePlayer.myRigidbody.velocity = Vector3.zero;
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("CoinCount",theLevelManager.coinCount);
        yield return new WaitForSeconds(waitToMove);
        movePlayer = true;
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
