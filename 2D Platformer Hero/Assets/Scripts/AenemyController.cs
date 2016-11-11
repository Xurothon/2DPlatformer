using UnityEngine;
using System.Collections;

public class AenemyController : MonoBehaviour {

    public float moveSpeed;
    private bool canMove;
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }
    }

    void OnBecameVisible()
    {
        canMove = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "KillPlane") {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
