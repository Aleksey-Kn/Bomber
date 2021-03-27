using UnityEngine;

public class ForBomb : MonoBehaviour
{
    private static float wether = 0f;
    public GameObject boom;
    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(3, wether) * Time.deltaTime);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            Spawn.miss();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Instantiate(boom, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.identity);
            Destroy(gameObject);
            Spawn.uppScore();
        }
    }

    public static void setWether(float w)
    {
        wether = w;
    }

    public static float getWether()
    {
        return Mathf.Round(wether * 10) / 10;
    }
}
