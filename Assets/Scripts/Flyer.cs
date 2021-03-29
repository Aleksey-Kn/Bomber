using UnityEngine;

public class Flyer : MonoBehaviour
{
    private float lastTime = 0;
    private float timeOfDown;
    private bool move = false;
    private float higth = 2;
    public GameObject bomb;
    private static bool play = true;
    public AudioClip audioClip;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 || Input.anyKey)
        {
            if (!play)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    timeOfDown = Time.time;
                } 
                else if (Input.GetTouch(0).phase == TouchPhase.Ended && Time.time - timeOfDown > 1)
                {
                    Movement.updateCount();
                    play = true;
                    move = true;
                    Spawn.die(false);
                }
            }
            else if (Time.time - lastTime >= 0.75)
            {
                lastTime = Time.time;
                Instantiate(bomb, new Vector3(-1.5f, (float)(transform.position.y - 0.1), -5), Quaternion.Euler(new Vector3(0, 0, 270)));
                GetComponent<AudioSource>().PlayOneShot(audioClip);
            }
        }
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
