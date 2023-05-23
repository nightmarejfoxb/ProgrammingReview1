using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{

    public BoxCollider2D box;
    private GameManager gameManager;
    public int pointValue;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        gameManager = GameObject.Find("MainGameCode").GetComponent<GameManager>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
        gameManager.UpdateScore(pointValue);
    }
}
