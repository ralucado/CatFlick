using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int catsSaved;
    // Start is called before the first frame update
    void Start()
    {
        catsSaved = 0;
        scoreText.text = "cats saved: 0";
    }

    public void saveACat()
    {
        ++catsSaved;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "cats saved: " + catsSaved;
    }
}
