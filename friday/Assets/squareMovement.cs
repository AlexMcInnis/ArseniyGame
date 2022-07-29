using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squareMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 dir;

    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;

        }
      
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

        else
        {
            dir = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {

        if (dir.sqrMagnitude != 0)
        {
            rb.AddForce(dir * speed);
        }

    }
}
