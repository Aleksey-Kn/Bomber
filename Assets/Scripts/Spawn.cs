using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] towns;
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(towns[Random.Range(0, towns.Length)], new Vector3(10, -5, -5), Quaternion.Euler(new Vector3(180, 90, 180)));
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }

    void FixedUpdate()
    {
        if (Random.Range(0, 1800) == 1)
        {
            ForBomb.setWether(Random.Range(-3, 1));
        }
    }
}
