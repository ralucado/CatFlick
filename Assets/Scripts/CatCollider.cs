using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollider : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer rend;
    public GameObject gameController;

    void Start()
    {
        rend = GetComponentInParent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
    public void setGameController(GameObject gameControllerInstance)
    {
        gameController = gameControllerInstance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            killTheCat();

        }
    }

    private void killTheCat()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<Collider2D>().enabled = false;
        startFading();
        gameController.SendMessage("killACat");
        gameObject.transform.parent.gameObject.BroadcastMessage("killACat");
    }

    public void startFading()
    {
        StartCoroutine("FadeOut");
    }

    // Start is called before the first frame update


    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= 0f; f -= 0.1f)
        {
            Vector3 pos = rend.transform.position;
            pos.y += 0.2f;
            rend.transform.position = pos;
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject.transform.parent.gameObject);

    }
}
