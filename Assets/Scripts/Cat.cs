using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool fromInside;
    public Animator animator;
    public MonoBehaviour gameController;

    private void Start()
    {
        fromInside = true;
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
            rb.AddForce(new Vector2(-xDir * 220, 400));
            //Debug.DrawRay(rb.position, new Vector3(-xDir * 80, 320, 9), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), 10f, false);
        }
        else if (someObject.CompareTag("Inner"))
            fromInside = true;
        else if (someObject.CompareTag("Outer") && !fromInside)
        {
            Debug.DrawLine(someObject.transform.position, rb.position, Color.black, 20f, false);
            Debug.Log("Scored a pointeroo!");
            animator.SetBool("Saved", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            gameController.SendMessage("saveACat");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Inner"))
            fromInside = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
