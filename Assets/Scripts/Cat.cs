using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool fromInside;
    public bool shake;
    public Animator animator;
    public GameObject gameController;
    private Vector3 shakePos;
    public AudioClip bounce;
    AudioSource audioSource;
    private void Start()
    {
        fromInside = true;
        shake = false;
        rb = GetComponentInParent<Rigidbody2D>();
        audioSource = GetComponentInParent<AudioSource>();
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
            audioSource.PlayOneShot(bounce, 0.7F);
        }
        else if (someObject.CompareTag("Inner"))
            fromInside = true;
        else if (someObject.CompareTag("Outer") && !fromInside)
        {
            shake = true;
            shakePos = transform.parent.position;
            animator.SetBool("Saved", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            gameController.SendMessage("saveACat");
            gameObject.GetComponent<Collider2D>().enabled = false;
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

    public void Update()
    {
        if (shake)
        {
            Vector3 pos = shakePos;
            pos.x += Mathf.Sin(Time.time * 120) * 0.02f;
            transform.parent.position = pos;
        }
    }
}
