using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool playerA = false;
    bool playerB = false;

    public float maxSpeed = 1.0f;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "PlayerA")
                playerA = true;

            else if (collision.gameObject.name =="PlayerB")
                playerB = true;

        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.name == "PlayerA")
                playerA = false;

            else if (collision.gameObject.name == "PlayerB")
                playerB = false;
        }

        void MoveBall()
    {
        if (playerA == true && playerB == true)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
            
        else
            rb.velocity = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        MoveBall();
    }
}
