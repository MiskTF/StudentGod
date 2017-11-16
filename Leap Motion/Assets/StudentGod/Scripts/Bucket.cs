using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
    
    // Update is called once per frame
    void Update () {
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == tag) {
            EventManager.FireOnStudentHit (col.gameObject);
            StartCoroutine(ScalingAnimation ());
        }
     }

    //TODO: Fix! a very tiny amount is lost each time. Likely not noticed due to rounding errors with 2%.
    IEnumerator ScalingAnimation() {
        for (int i = 0; i <= 10; i++) {
            yield return new WaitForSeconds (0.001f);
            transform.localScale *= 1.02f;
            //transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1.02f,1.10f,1.02f));
        }
        for (int i = 0; i <= 10; i++) {
            yield return new WaitForSeconds (0.001f);
            transform.localScale *= 0.98f;
            //transform.localScale = Vector3.Scale(transform.localScale, new Vector3(0.98f,0.90f,0.98f));
        }
    }
}
