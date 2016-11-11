using UnityEngine;
using System.Collections;

public class BenemyController : MonoBehaviour {

    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public bool movingRight;

	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (movingRight && transform.position.x > rightPoint.position.x) {
            movingRight = false;
        }
        if (!movingRight && transform.position.x < leftPoint.position.x) {
            movingRight = true;
        }
        if (movingRight)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
        }
        else {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }
	
	}
}
