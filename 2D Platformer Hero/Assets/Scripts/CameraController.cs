using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float followAhead;
    public float smoothing;
    public bool followTarget;
    private Vector3 targetPosition;

    private void Start()
    {
        followTarget = true;
    }

    private void Update()
    {
        if (followTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

            if (target.transform.localScale.x > 0f)
            {
                targetPosition += new Vector3(followAhead, 0, 0);
            }
            else
            {
                targetPosition -= new Vector3(followAhead, 0, 0);
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}


