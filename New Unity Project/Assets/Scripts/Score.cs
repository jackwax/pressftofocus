using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    // Use this for initialization
    private Text scoretext;
    private float score;
    private bool inGame;


    [SerializeField]
    private int multiplier = 10000;

	void Start () {
        score = 0;
        scoretext = this.GetComponent<Text>();
        inGame = false;
		
	}

    public void StartGame()
    {
        inGame = true;
    }

    public float GetScore()
    {
        return score;
    }

    private void reset()
    {
        score = 0;
        scoretext.text = "";
        inGame = false;

        
    }

    // Update is called once per frame
    void Update () {
        if (inGame)
        {
            score += Time.deltaTime * multiplier;
            scoretext.text = "Score: " + score;
        }
        else
        {
            reset();

        }


		
	}
}
