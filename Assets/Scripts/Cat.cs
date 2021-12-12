using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.CompareTag("Player"))
        {
            Debug.Log("Flickittycat!");
            // rb.AddForce(new Vector2(0, 300));
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
            float xDir = someObject.gameObject.transform.position.x - rb.position.x;
            rb.AddForce(new Vector2(-xDir* 220, 420));
            //Debug.DrawRay(rb.position, new Vector3(-xDir * 80, 320, 9), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f, false);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
