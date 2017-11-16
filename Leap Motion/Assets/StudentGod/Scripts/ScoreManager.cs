using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {

    private static class Score {
        public static int score{ get; private set;}
        public static int hits{ get; private set;}
        public static int lates{ get; private set;}
        public static int misses{ get; private set;} 

        public static void initializeScore() {
            score = 0;
            hits = 0;
            lates = 0;
            misses = 0;
        }

        public static void IncreaseScore(int amount) {
            score += amount;
        }

        public static void DecreaseScore(int amount) {
            score -= amount;
        }

        public static void IncreaseHits() {
            hits++;
        }

        public static void IncreaseLates() {
            lates++;
        }

        public static void IncreaseMisses() {
            misses++;
        }
    }
}
