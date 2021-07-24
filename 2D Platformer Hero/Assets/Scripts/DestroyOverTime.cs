using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime;

    private void Update()
    {
        lifeTime = lifeTime - Time.deltaTime;
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
