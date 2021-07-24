using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ResetOnRespawn : MonoBehaviour
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Vector3 _startLocalScale;
    private Rigidbody2D _myRidybody;

    public void ResetObject()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        transform.localScale = _startLocalScale;
        if (_myRidybody != null)
        {
            _myRidybody.velocity = Vector3.zero;
        }
    }

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _startLocalScale = transform.localScale;
        _myRidybody = GetComponent<Rigidbody2D>();
    }
}