using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 2.5f;
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
