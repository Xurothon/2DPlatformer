using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    public float bounceForce;
    public GameObject deathSplosion;
    private Rigidbody2D playerRigidbody;

    private void Start()
    {
        playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            Instantiate(deathSplosion, other.transform.position, other.transform.rotation);
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, bounceForce, 0f);
        }
    }
}