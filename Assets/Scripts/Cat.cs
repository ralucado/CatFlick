using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool fromInside;
    public Animator animator;
    public GameObject gameController;

    private void Start()
    {
        fromInside = true;
        rb = GetComponentInParent<Rigidbody2D>();
    }

    public void setGameController(GameObject gameControllerInstance)
    {
        gameController = gameControllerInstance;
    }
    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.CompareTag("Player"))
        {
            //Debug.Log("Flickittycat!");
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
            float xDir = someObject.gameObject.transform.position.x - rb.position.x;
            rb.AddForce(new Vector2(-xDir * 220, 420));
        }
        else if (someObject.CompareTag("Inner"))
            fromInside = true;
        else if (someObject.CompareTag("Outer") && !fromInside)
        {
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

    public void killACat()
    {
        GetComponent<Collider2D>().enabled = false;
        animator.SetBool("Ded", true);
    }
}
