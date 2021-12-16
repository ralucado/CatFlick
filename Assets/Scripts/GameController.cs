﻿using System.Collections;
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
    private float lastTimeInterval;
    int extraCats;
    AudioSource audioSource;
    public AudioClip purr;
    public AudioClip die;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        catsSaved = 0;
        catsDead = 0;
        updateText(scoreText, catsSaved);
        updateText(dedText, catsDead);
        lastTimeInterval = Time.realtimeSinceStartup;
        extraCats = 0;
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
        audioSource.PlayOneShot(purr, 1);
        newCat();
    }

    public void killACat()
    {
        ++catsDead;
        audioSource.PlayOneShot(die, 0.3f);
        newCat();
    }

    // Update is called once per frame
    void Update()
    {
        updateText(scoreText, catsSaved);
        updateText(dedText, catsDead);

        nice();
        if(extraCats < 3)
        {
            if(Time.realtimeSinceStartup - lastTimeInterval > 30)
            {
                lastTimeInterval = Time.realtimeSinceStartup;
                newCat();
                ++extraCats;
            }

        }
    }

    private void nice()
    {
        if (catsSaved == 69)
            scoreText.text += "\n nice";
    }
}
