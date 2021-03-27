using System.Collections;
using UnityEngine;

public class Destr : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(delete());
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
