using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed;
    public Animator animator;
    public bool right = true;
    public int activeTouches;
    private void Start()
    {
        activeTouches = 0;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 4;
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
                        ++activeTouches;
                        if (touch.position.x < Screen.width / 2)
                        {
                            rb.velocity = new Vector2(-moveSpeed, 0f);
                            right = false;
                            animator.SetBool("Idle", false);
                            animator.SetBool("Right", right);
                            animator.SetBool("Left", !right);

                        }
                        if (touch.position.x >= Screen.width / 2)
                        {
                            rb.velocity = new Vector2(moveSpeed, 0f);
                            right = true;
                            animator.SetBool("Idle", false);
                            animator.SetBool("Right", right);
                            animator.SetBool("Left", !right);
                        }
                        break;

                    case TouchPhase.Ended:
                        --activeTouches;
                        if (activeTouches == 0)
                        {
                            rb.velocity = new Vector2(0f, 0f);
                            animator.SetBool("Idle", true);
                            animator.SetBool("Right", right);
                            animator.SetBool("Left", !right);
                        }
                        break;
                }
            }
           
        }
    }
}
