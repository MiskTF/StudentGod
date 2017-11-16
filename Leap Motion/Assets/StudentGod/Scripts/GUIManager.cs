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
        
        int hits = ScoreManager.Score.hits;
        int lates = ScoreManager.Score.lates;
        int misses = ScoreManager.Score.misses;
        string text = "Hits  : " + hits  + "\n" +
                      "Lates : " + lates + "\n" +
                      "Misses: " + misses;
        GUI.Box(new Rect(0,0, 50, 50), text,style);
    }
}
