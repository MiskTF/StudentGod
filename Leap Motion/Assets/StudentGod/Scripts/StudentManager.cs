using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour {

    public string[] tags;
    public Material[] colors;
    public Transform[] spawnPoints;
    public GameObject studentPrefab;

    int successfulStudents;
    int lateStudents;
    int failedStudents;

    ArrayList students;
	// Use this for initialization
	void Start () {
        students = new ArrayList ();
        StartCoroutine (SpawnStudents ());
        EventManager.OnStudentHit    += StudentSuccessful;
        EventManager.OnStudentLate   += StudentLate;
        EventManager.OnStudentMissed += StudentFailed;
    }
    // Update is called once per frame
    void Update () {
        
    }

    IEnumerator SpawnStudents() {
        while (true) {
            if (students.Count <= 10) {
                int number = Random.Range (0, colors.Length);
                int spawn = Random.Range (0, spawnPoints.Length);
                GenerateStudent (number, spawn);
            }
            yield return new WaitForSeconds (2f);
        }
    }

    void GenerateStudent(int number, int spawn) {
        GameObject newStudent = Instantiate (studentPrefab,spawnPoints[spawn].position, Quaternion.identity);
        newStudent.tag = tags[number];
        newStudent.GetComponent<Renderer>().material = colors[number];
        students.Add (newStudent);
    }

    void StudentSuccessful(GameObject obj) {
        successfulStudents++;
        DestroyStudent (obj);
    }

    void StudentFailed(GameObject obj) {
        failedStudents++;
        DestroyStudent (obj);
    }
    void StudentLate(GameObject obj) {
        lateStudents++;
        DestroyStudent (obj);
    }

    void DestroyStudent(GameObject obj) {
        students.Remove (obj);
        obj.GetComponent<StudentBehaviour> ().RemoveStudent (); 
    }

}
