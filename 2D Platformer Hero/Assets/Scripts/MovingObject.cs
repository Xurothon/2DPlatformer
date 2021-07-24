using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public GameObject objectToMove;
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;
    private Vector3 _currentTarget;

    void Start()
    {
        _currentTarget = endPoint.position;
    }

    void Update()
    {
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, _currentTarget, moveSpeed * Time.deltaTime);
        if (objectToMove.transform.position == endPoint.position)
        {
            _currentTarget = startPoint.position;
        }
        if (objectToMove.transform.position == startPoint.position)
        {
            _currentTarget = endPoint.position;
        }
    }
}
