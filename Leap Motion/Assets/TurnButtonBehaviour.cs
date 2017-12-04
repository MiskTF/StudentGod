using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
public class TurnButtonBehaviour : InteractionBehaviour {

    public int isRight;
    public Transform pivot;
    public float turnSpeed;

	// Use this for initialization
	protected override void Start () {
        base.Start ();  
        OnHoverStay += turn;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void turn() {
        pivot.Rotate (new Vector3(0,turnSpeed*isRight*Time.deltaTime,0));
    }


}
