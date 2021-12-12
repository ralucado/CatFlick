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
            rb.AddForce(new Vector2(0, 300));
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
