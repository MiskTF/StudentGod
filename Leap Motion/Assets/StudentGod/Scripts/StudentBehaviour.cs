using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class StudentBehaviour : InteractionBehaviour {

    bool prevGrabbed;
    public GUIStyle style;
    int count;

	// Use this for initialization
    protected override void Start () {
        base.Start ();
        prevGrabbed = false;
        OnGraspBegin += SetTrigger;
        OnGraspEnd += SetGrabbed;
        count = 15;
        StartCoroutine (Countdown());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetTrigger() {
        this.GetComponent<BoxCollider> ().isTrigger = true;
    }

    void SetGrabbed() {
        prevGrabbed = true;
        StartCoroutine (delayedCollider());
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Ground" && prevGrabbed) {
            EventManager.FireOnStudentMissed(this.gameObject);
        }
    }

    public void RemoveStudent() {
        //TODO: Probably not needed.
        OnGraspEnd -= SetGrabbed;
        Destroy (gameObject);
    }

    void OnGUI() {
        Vector2 worldPoint = Camera.main.WorldToScreenPoint (transform.position);
        GUI.Label(new Rect(worldPoint.x-30, (Screen.height - worldPoint.y) - 130, 200,100),"" + count, style);
    }

    IEnumerator Countdown() {
        while (count > 0) {
            count--;
            yield return new WaitForSeconds (1f);
        }
        EventManager.FireOnStudentLate (this.gameObject);
    }

    IEnumerator delayedCollider() {
        yield return new WaitForSeconds (0.1f);
        this.GetComponent<BoxCollider> ().isTrigger = false;
    }
}
