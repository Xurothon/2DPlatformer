using UnityEngine;
using System.Collections;

public class ResetOnRespawn : MonoBehaviour {

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startLocalScale;
    private Rigidbody2D myRidybody;

	void Start () {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;
        if (GetComponent<Rigidbody2D>() != null) {
            myRidybody = GetComponent<Rigidbody2D>();
        }
        
	}
	
	void Update () {
	
	}

    public void ResetObject() {
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;
        if (myRidybody != null) {
            myRidybody.velocity = Vector3.zero;
        }
    }
}
