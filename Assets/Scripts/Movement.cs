using UnityEngine;

public class Movement : MonoBehaviour
{
    private const float speed = 2.5f;
    private static int missCount = 0;
    void FixedUpdate()
    {
        int score = Spawn.getScore();
        transform.Translate(Vector3.forward * speed * Time.deltaTime * (1 + (score < 300? (float)score / 300: Mathf.Log(score, 2) / 8)));

        if(transform.position.x < -10)
        {
            Destroy(gameObject);
            missTower();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(gameObject);
        }
    }

    private static void missTower()
    {
        if(++missCount == 10)
        {
            Flyer.die();
            Spawn.die(true);
        }
    }

    public static void updateCount()
    {
        missCount = 0;
    }
}
