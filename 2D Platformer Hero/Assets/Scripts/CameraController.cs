using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    public float followAhead;
    public float smoothing;
    private Vector3 targetPosition;
    public bool followTarget;

    void Start()
    {
        followTarget = true;
    }

    void Update()
    {
        if (followTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

            if (target.transform.localScale.x > 0f)
            {
                targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);

            }
            else
            {
                targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
            }

            //transform.position = targetPosition;

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}


