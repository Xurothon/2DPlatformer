using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class LevelEnd : MonoBehaviour
{
    public string levelToLoad;
    public string levelToUnlock;
    public float waitToMove;
    public float waitToLoad;
    public Sprite flagOpen;
    private SpriteRenderer _spriteRender;
    private PlayerController _player;
    private CameraController _cameraControllet;
    private LevelManager _levelManager;
    private bool _isPlayerMove;

    private void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _cameraControllet = FindObjectOfType<CameraController>();
        _levelManager = FindObjectOfType<LevelManager>();
        _spriteRender = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (_isPlayerMove)
        {
            _player.playerRigidbody.velocity = new Vector3(_player.moveSpeed, _player.playerRigidbody.velocity.y, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _spriteRender.sprite = flagOpen;
            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
        _player.canMove = false;
        _cameraControllet.followTarget = false;
        _levelManager.invincible = true;
        _player.playerRigidbody.velocity = Vector3.zero;
        PlayerPrefs.SetInt("CoinCount", _levelManager.coinCount);
        PlayerPrefs.SetInt("PlayerLives", _levelManager.currentLives);
        PlayerPrefs.SetInt(levelToUnlock, 1);
        yield return new WaitForSeconds(waitToMove);
        _isPlayerMove = true;
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
