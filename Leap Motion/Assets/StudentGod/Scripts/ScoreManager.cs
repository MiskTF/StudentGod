using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {

    static int scoreIncrease = 5;


    public static class Score {

        public static int score{ get; private set;}
        public static int hits{ get; private set;}
        public static int lates{ get; private set;}
        public static int misses{ get; private set;} 

        public static void initializeScore() {
            EventManager.OnStudentHit += Score.IncreaseHits;
            EventManager.OnStudentLate += Score.IncreaseLates;
            EventManager.OnStudentMissed += Score.IncreaseMisses;
            
            misses = 0;
            score = 0;
            hits = 0;
            lates = 0;
        }

        static void IncreaseScore() {
            score += scoreIncrease;
        }

        static void DecreaseScore() {
            score -= scoreIncrease;
        }


        //TODO: UGLY! Since they done need the obj. Figure something out.
        public static void IncreaseHits(GameObject obj) {
            IncreaseScore ();
            hits++;
        }

        public static void IncreaseLates(GameObject obj) {
            DecreaseScore ();
            lates++;
        }

        public static void IncreaseMisses(GameObject obj) {
            DecreaseScore ();
            misses++;
        }
    }
}
