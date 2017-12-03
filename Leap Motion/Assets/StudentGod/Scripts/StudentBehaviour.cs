using System;
using System.Collections;
using UnityEngine;
using Leap.Unity.Interaction;
public class StudentBehaviour : InteractionBehaviour {

    bool prevGrabbed;
    public GUIStyle style;
    int count;
    Animator animator;

    /* all of this doesn't work -Eva
    int startJumpHash = Animator.StringToHash("Basejump-up");
    int idleHash = Animator.StringToHash("idle");
    int waveHash = Animator.StringToHash("wave");
    int wave2Hash = Animator.StringToHash("wave2hands");

    
   // bool normal = true;
    bool wave = false;
    bool wave2 = false;
    int wavingcount = 10;*/

	// Use this for initialization
    protected override void Start () {
        base.Start ();
        prevGrabbed = false;
        OnGraspBegin += SetTrigger;
        OnGraspEnd += SetGrabbed;
        animator = GetComponent<Animator>();
        count = 15;
        StartCoroutine (Countdown());
       // StartCoroutine(Countwave());
    }
	
	// Update is called once per frame
	void Update () {
		/* all of this doesn't work -Eva
        if (wave)
        {
            animator.SetTrigger(waveHash);
        }
        if (wave2)
        {
            animator.SetTrigger(wave2Hash);
        }
       */
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            Vector3 newPosition = transform.position;
            newPosition.z += animator.GetFloat("WalkSpeed") * Time.deltaTime;
            transform.position = newPosition;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            Vector3 newPosition = transform.position;
            newPosition.z += animator.GetFloat("RunSpeed") * Time.deltaTime;
            transform.position = newPosition;
        }
        
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
//        Vector2 worldPoint = Camera.main.WorldToScreenPoint (transform.position);
  //      GUI.Label(new Rect(worldPoint.x-30, (Screen.height - worldPoint.y) - 130, 200,100),"" + count, style);
    }

    IEnumerator Countdown() {
        while (count > 0) {
            count--;
            yield return new WaitForSeconds (1f);
        }
        EventManager.FireOnStudentLate (this.gameObject);
    }
	/* all of this doesn't work -Eva
    IEnumerator Countwave()
    {
        wave = false;
        wave2 = false;
        while (wavingcount > 0)
        {
            wavingcount--;
            yield return new WaitForSeconds(1f);
        }
        System.Random randNum = new System.Random();
        int test = randNum.Next(11);
        if (test < 5) {
            wave = true;
        }
        else
        {
            wave2=true;
        }

    }*/

    IEnumerator delayedCollider() {
        yield return new WaitForSeconds (0.1f);
        this.GetComponent<BoxCollider> ().isTrigger = false;
    }

   
}
