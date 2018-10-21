using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    public bool facingRight = true;
    public Text countText;
    int count;
    private AudioSource source;
    public AudioClip jumpClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    private void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);


        if (facingRight == false && moveHorizontal > 0) {
            Flip(); }
        else if (facingRight == true && moveHorizontal < 0) {
            Flip(); }

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void Awake()
    {
    source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Ground" && isOnGround)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpForce;
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpClip);
            }
        }
    }

    void Flip()
    {
    facingRight = !facingRight;
    Vector2 Scaler = transform.localScale;
    Scaler.x = Scaler.x * -1;
    transform.localScale = Scaler;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
