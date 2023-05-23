using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator ab;
    Rigidbody2D rb;
    public float moveSpeed;
    public float horizontalInput;
    public SpriteRenderer spriteRenderer;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ab = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * horizontalInput);
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void Hurt()
    {
        ab.SetTrigger("died");
        StartCoroutine(DeathDelay());
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ab.SetTrigger("died");
            Invoke("DestroyPlayer", 4);
        }
    }
    
        
    
    void FixedUpdate()
    {
        // Move player based on movement input
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);
    }
    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
