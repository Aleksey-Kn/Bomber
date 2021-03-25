using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1.5f;
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
