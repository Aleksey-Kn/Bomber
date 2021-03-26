using UnityEngine;

public class Flyer : MonoBehaviour
{
    private float lastTime = 0;
    private bool move = false;
    private float higth = 2;
    public GameObject bomb;

    // Update is called once per frame
    void Update()
    {
        if((Input.touchCount > 0 || Input.anyKey) && Time.time - lastTime >= 1)
        {
            lastTime = Time.time;
            Instantiate(bomb, new Vector3(-1.5f, (float)(transform.position.y - 0.1), -5), Quaternion.Euler(new Vector3(0, 0, 270)));
        }
    }

    private void FixedUpdate()
    {
        if (!move)
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
}
