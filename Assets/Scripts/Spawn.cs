using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] towns;
    private static int score = 0;
    private Rect forScore = new Rect(30, 3, 150, 20);
    private Rect forWind = new Rect(Screen.width - 150, 3, 150, 20);
    private Rect forDie = new Rect(Screen.width / 2 - 150, 150, 300, 100);
    private static bool play = true;
    private GUIStyle GUIStyle = new GUIStyle();
    private GUIStyle mainStyle = new GUIStyle();

    void Start()
    {
        StartCoroutine(spawn());
        GUIStyle.fontSize = 70;
        GUIStyle.fontStyle = FontStyle.Bold;
        mainStyle.normal.textColor = Color.white;
        mainStyle.fontSize = 32;
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
            ForBomb.setWether(Random.Range(-3f, 1f));
        }
    }

    private void OnGUI()
    {
        if (!play)
        {
            GUI.Label(forDie, "Поражение! Счёт: " + score, GUIStyle);
        }
        GUI.Label(forScore, "Score: " + score, mainStyle);
        GUI.Label(forWind, "Wind: " + ForBomb.getWether(), mainStyle);
    }

    public static void uppScore()
    {
        score+= 10;
    }

    public static void miss()
    {
        score -= 5;
    }

    public static int getScore()
    {
        return score;
    }

    public static void die(bool status)
    {
        if (status)
        {
            play = false;
        }
        else
        {
            score = 0;
            play = true;
        }
    }
}
