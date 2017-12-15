using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
public class TurnButtonBehaviour : InteractionBehaviour {

    public int isRight;
    public Transform pivot;
    public Transform leapSpace;
    public Transform playerView;
    public float turnSpeed;

    Vector3 leapOrigin;
    Vector3 camOrigin;

	// Use this for initialization
	protected override void Start () {
        base.Start ();  
        OnHoverStay += turn;

        leapOrigin = leapSpace.position + leapSpace.forward;
        camOrigin = playerView.position + playerView.forward;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //Used for resetting leapspace to front when camera gets out of sync.
        if (Input.GetKeyDown("r")) {
            leapSpace.LookAt(leapOrigin,Vector3.up);
            playerView.LookAt (camOrigin, Vector3.up);
        }
	}

    void turn() {
        pivot.Rotate (new Vector3(0,turnSpeed*isRight*Time.deltaTime,0));
    }


}
