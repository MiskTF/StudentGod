using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeReset : MonoBehaviour {

    public GameObject[] cubes;

    Vector3[] positions;
	// Use this for initialization
	void Start () {
        positions = new Vector3[cubes.Length];
        int count = 0;
        foreach(GameObject cube in cubes) {
            positions [count] = cube.transform.position;
            count++;
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown ("r")) {
            ResetCubes ();
        }
	}

    void ResetCubes() {
        int count = 0;
        foreach(GameObject cube in cubes) {
            cube.transform.position = positions [count];
            cube.SetActive (true);
            count++;
        }
    }
}
