using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BenemyController : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed;
    private Rigidbody2D _myRigidbody;
    public bool _isMovingRight;

    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isMovingRight && transform.position.x > rightPoint.position.x)
        {
            _isMovingRight = false;
        }
        if (!_isMovingRight && transform.position.x < leftPoint.position.x)
        {
            _isMovingRight = true;
        }
        if (_isMovingRight)
        {
            _myRigidbody.velocity = new Vector3(moveSpeed, _myRigidbody.velocity.y, 0f);
        }
        else
        {
            _myRigidbody.velocity = new Vector3(-moveSpeed, _myRigidbody.velocity.y, 0f);
        }
    }
}
