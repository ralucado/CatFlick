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
        catsDead = 0;
        updateText(scoreText, catsSaved);
        updateText(dedText, catsDead);
    }

    private void updateText(Text text, int num)
    {
        text.text = num.ToString();
    }

    private void newCat()
    {
        GameObject cat = Instantiate(catPrefab, new Vector3(Random.Range(-2.0f, 2.0f), 14, 0), Quaternion.identity);
        cat.BroadcastMessage("setGameController", gameObject);
    }

    public void saveACat()
    {
        ++catsSaved;
        newCat();
    }

    public void killACat()
    {
        ++catsDead;
        newCat();
    }

    // Update is called once per frame
    void Update()
    {
        updateText(scoreText, catsSaved);
        updateText(dedText, catsDead);

        nice();
    }

    private void nice()
    {
        if (catsSaved == 69)
            scoreText.text += "\n nice";
    }
}
