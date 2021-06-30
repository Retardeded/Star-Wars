using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scoreFactor = 10;
    int score;
    Text scoreText;
    void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }
    public void ScoreHit(int hitFactor)
        {
        score = score + hitFactor;
        scoreText.text = score.ToString();
    }
	
}
