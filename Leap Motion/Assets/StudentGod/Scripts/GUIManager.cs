using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GUIManager : MonoBehaviour {

    public GUIStyle style;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    void OnGUI() {

        //ScoreManager.Score score = ScoreManager.GetScore ();

        //ScoreManager.gameScore.

        int hits = 5;
        int lates = 6;
        int misses = 10;
        string text = "Hits  : " + hits  + "\n" +
                      "Lates : " + lates + "\n" +
                      "Misses: " + misses;
        GUI.Box(new Rect(0,0, 50, 50), text,style);
    }
}
