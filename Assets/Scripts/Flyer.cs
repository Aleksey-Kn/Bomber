using UnityEngine;

public class Flyer : MonoBehaviour
{
    private float lastTime = 0;
    private bool move = false;
    private float higth = 2;
    public GameObject bomb;
    private static bool play = true;

    // Update is called once per frame
    void Update()
    {
        if((Input.touchCount > 0 || Input.anyKey) && Time.time - lastTime >= 1 && play)
        {
            lastTime = Time.time;
            Instantiate(bomb, new Vector3(-1.5f, (float)(transform.position.y - 0.1), -5), Quaternion.Euler(new Vector3(0, 0, 270)));
        } else if(!play && (Input.touchCount > 1 || Input.anyKey))
        {
            lastTime = Time.time;
            Movement.updateCount();
            play = true;
            move = true;
            Spawn.die(false);
        }
    }

    private void FixedUpdate()
    {
        if (play)
        {
            if (!move && play)
            {
                if (Random.Range(0, 1200) == 1)
                {
                    move = true;
                    higth = Random.Range(-2f, 4f);
                }
            }
            else
            {
                if (Mathf.Abs(transform.position.y - higth) < 0.02)
                {
                    move = false;
                }
                else
                {
                    transform.Translate(Vector3.up * 0.02f * Mathf.Sign(higth - transform.position.y));
                }
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.y - 6) > 0.05)
            {
                transform.Translate(Vector3.up * 0.05f);
            }
        }
    }

    public static void die()
    {
        play = false;
    }
}
