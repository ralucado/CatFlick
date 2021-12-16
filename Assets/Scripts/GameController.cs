using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text dedText;
    public int catsSaved;
    public int catsDead;
    public GameObject catPrefab;
    // Start is called before the first frame update
    void Start()
    {
        catsSaved = 0;
        scoreText.text = catsSaved.ToString();
        catsDead = 0;
        dedText.text = catsDead.ToString();

    }

    public void saveACat()
    {
        ++catsSaved;
        GameObject cat = Instantiate(catPrefab, new Vector3(Random.Range(-2.0f, 2.0f), 14, 0), Quaternion.identity);
        cat.BroadcastMessage("setGameController", gameObject);
    }

    public void killACat()
    {
        ++catsDead;
        GameObject cat = Instantiate(catPrefab, new Vector3(Random.Range(-2.0f, 2.0f), 14, 0), Quaternion.identity);
        cat.BroadcastMessage("setGameController", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        dedText.text = catsDead + "";
        scoreText.text = catsSaved + "";
        if (catsSaved == 69)
            scoreText.text += "\n nice";
    }
}
