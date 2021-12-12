using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D someObject)
    {
        if (someObject.CompareTag("Cat"))
        {
            Debug.Log("Cat flicked to safety!");

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
