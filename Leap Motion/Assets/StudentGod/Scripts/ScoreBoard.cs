using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    public TextMesh scoreBoard;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void LateUpdate () {

        int hits = ScoreManager.Score.hits;
        int lates = ScoreManager.Score.lates;
        int misses = ScoreManager.Score.misses;

        int score = hits * 5 - (lates+misses) ;

        string text = "Score  : " + score  + "\n\n" +
            "Hits : " + hits + "\n" +
            "Fails: " + (misses + lates);
        
        scoreBoard.text = text;
    }
}
