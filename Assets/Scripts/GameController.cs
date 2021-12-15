using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int catsSaved;
    public GameObject catPrefab;
    // Start is called before the first frame update
    void Start()
    {
        catsSaved = 0;
        scoreText.text = "cats saved: 0";
    }

    public void saveACat()
    {
        ++catsSaved;
        GameObject cat = Instantiate(catPrefab, new Vector3(Random.Range(-2.0f, 2.0f), 14, 0), Quaternion.identity);
        cat.GetComponentInChildren<Cat>().SendMessage("setGameController", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "cats saved: " + catsSaved;
    }
}
