using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public MoveRacet MoveRacet;
    public Vector2 direction;
    public float speed;
    public GameObject restart;
    public int score;
    public int record;
    public Text txt;
    public static bool lose = false;

    void Awake()
    {
        lose = false;
    }

    void Start()
    {
        transform.position = Vector2.zero;
        float scale = UnityEngine.Random.Range(0.2f, 0.4f);
        transform.localScale = new Vector2(scale, scale);
        direction = new Vector2(Random.Range(0.5f, 1), Random.Range(0.5f, 1));
        speed = Random.Range(5, 12);
    }

    void Update()
    {
        rigidbody.velocity = direction.normalized * speed;

        if (score > record)
        {
            PlayerPrefs.SetInt("savescore", score);
            PlayerPrefs.Save();
        }
        record = PlayerPrefs.GetInt("savescore");
        txt.text = "RECORD:" + record;

        if (transform.position.y > MoveRacet.racetTop.transform.position.y + 1 ||
            transform.position.y < MoveRacet.racetBottom.transform.position.y - 1)
        {
            lose = true;
            restart.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RacetTop"))
        {
            direction.y = -direction.y;
            score = score + 1;
        }

        if (collision.gameObject.CompareTag("RacetBottom"))
        {
            direction.y = -direction.y;
            score = score + 1;
        }

        if (collision.gameObject.CompareTag("WallRight"))
        {
            direction.x = -direction.x;
        }

        if (collision.gameObject.CompareTag("WallLeft"))
        {
            direction.x = -direction.x;
        }
    }
}