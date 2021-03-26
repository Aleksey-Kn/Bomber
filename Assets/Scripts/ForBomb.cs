using UnityEngine;

public class ForBomb : MonoBehaviour
{
    private static float wether = 0f;
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(3, -wether) * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    public static void setWether(float w)
    {
        wether = w;
    }
}
