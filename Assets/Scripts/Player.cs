using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    public Animator animator;
    public bool direction = true;
    public int activeTouches;
    public GameObject room;
    private Vector3 roomstartPos;
    private void Start()
    {
        activeTouches = 0;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 4;
        roomstartPos = room.transform.position;
    }

    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.CompareTag("CatFlickTrigger"))
        {
            //Debug.Log("Prepare to Flickittycat!");
            animator.SetTrigger("Flick");
        }
    }

    private void setWalkAnimation(bool moving, bool direction)
    {
        animator.SetBool("Idle", !moving);
        animator.SetBool("Right", direction);
        animator.SetBool("Left", !direction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        //Debug.Log("Click!");
                        ++activeTouches;
                        if (touch.position.x < Screen.width / 2)
                        {
                            rb.velocity = new Vector2(-moveSpeed, 0f);
                            direction = false;
                        }
                        if (touch.position.x >= Screen.width / 2)
                        {
                            rb.velocity = new Vector2(moveSpeed, 0f);
                            direction = true;
                        }
                        setWalkAnimation(true, direction);
                    
                        break;

                    case TouchPhase.Ended:
                        --activeTouches;
                        setWalkAnimation(false, direction);
                        if (activeTouches == 0)
                        {
                            rb.velocity = new Vector2(0f, 0f);
                        }
                        break;
                }
            }
           
            //room.transform.position = roomstartPos + new Vector3(transform.position.x / 20.0f, 0, 0);
        }
    }
}
