using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour{

    public static Score gameScore;

    class Score() {
        public static int score  = 0;
        public static int hits   = 0;
        public static int lates  = 0;
        public static int misses = 0; 
    }

    public static void initializeScore() {
        gameScore = new Score();
    }

    public static void IncreaseScore(int amount) {
        gameScore.score += amount;
    }

    public static void DecreaseScore(int amount) {
        gameScore.score -= amount;
    }

    public static void IncreaseHits() {
        gameScore.hits++;
    }

    public static void IncreaseLates() {
        gameScore.lates++;
    }

    public static void IncreaseMisses() {
        gameScore.misses++;
    }

    public static Score GetScore() {
        return gameScore;
    }
}
